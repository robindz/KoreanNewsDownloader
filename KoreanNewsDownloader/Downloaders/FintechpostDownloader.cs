using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class FintechpostDownloader : DownloaderBase
    {
        public FintechpostDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.fintechpost.co.kr", "fintechpost.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://cds.fintechpost.co.kr{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}
