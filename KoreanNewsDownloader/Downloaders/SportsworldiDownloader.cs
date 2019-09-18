using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SportsworldiDownloader : DownloaderBase
    {
        public SportsworldiDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.sportsworldi.com", "sportsworldi.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("//") ? $"http:{x.GetAttributeValue("src", "")}"
                                                                             : x.GetAttributeValue("src", ""));
        }
    }
}
