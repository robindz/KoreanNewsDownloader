using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KyeonginDownloader : DownloaderBase
    {
        public KyeonginDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.kyeongin.com", "kyeongin.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@id=\"newsimg\"]")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
