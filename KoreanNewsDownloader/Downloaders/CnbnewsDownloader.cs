using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class CnbnewsDownloader : DownloaderBase
    {
        public CnbnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "weekly.cnbnews.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"news_body_area\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/data/") ? $"http://weekly.cnbnews.com{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}
