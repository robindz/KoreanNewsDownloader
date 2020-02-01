using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ThedriveDownloader : DownloaderBase
    {
        public ThedriveDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.thedrive.co.kr", "thedrive.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                    .SelectNodes("//*[@id=\"viewConts\"]//img")
                    .Select(x => x.GetAttributeValue("src", string.Empty).StartsWith("/news/") ? $"http://www.thedrive.co.kr{x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty)}"
                                                                                               : x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty));
        }
    }
}
