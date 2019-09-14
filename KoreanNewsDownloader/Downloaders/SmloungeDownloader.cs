using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SmloungeDownloader : DownloaderBase
    {
        public SmloungeDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.smlounge.co.kr", "smlounge.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//div[@class=\"itemImg \"]/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/upload/") ? $"https://img.smlounge.co.kr{x.GetAttributeValue("src", "")}"
                                                                                   : x.GetAttributeValue("src", ""));
        }
    }
}
