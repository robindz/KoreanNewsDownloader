using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ChristiantodayDownloader : DownloaderBase
    {
        public ChristiantodayDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.christiantoday.co.kr", "christiantoday.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//article[@class=\"full\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .Select(x => x.Substring(0, x.LastIndexOf("?")));
        }
    }
}
