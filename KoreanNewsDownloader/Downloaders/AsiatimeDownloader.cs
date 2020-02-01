using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiatimeDownloader : DownloaderBase
    {
        public AsiatimeDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.asiatime.co.kr", "asiatime.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.AbsoluteUri.Contains("newsview.php"))
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@id=\"viewConts\"]//img")
                    .Select(x => x.GetAttributeValue("src", string.Empty).StartsWith("/news/") ? $"http://www.asiatime.co.kr{x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty)}"
                                                                                               : x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty));
            }

            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"viewConts\"]")
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", string.Empty).StartsWith("/news/") ? $"http://www.asiatime.co.kr{x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty)}"
                                                                                           : x.GetAttributeValue("src", string.Empty).Replace("_thum", string.Empty));
        }
    }
}
