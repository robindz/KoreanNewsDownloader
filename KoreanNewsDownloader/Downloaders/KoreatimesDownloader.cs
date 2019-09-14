using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KoreatimesDownloader : DownloaderBase
    {
        public KoreatimesDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.koreatimes.co.kr", "koreatimes.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"view_article\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .Select(x => x.Substring(0, x.LastIndexOf(".jpg") + 4));
        }
    }
}
