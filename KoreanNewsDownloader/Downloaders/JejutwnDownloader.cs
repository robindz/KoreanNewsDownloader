using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class JejutwnDownloader : DownloaderBase
    {
        public JejutwnDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.jejutwn.com", "jejutwn.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"cnt_view news_body_area\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/data/") ? $"http://www.jejutwn.com{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}
