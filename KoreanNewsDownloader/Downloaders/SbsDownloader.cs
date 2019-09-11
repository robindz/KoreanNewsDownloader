using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    public class SbsDownloader : DownloaderBase
    {
        public SbsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "sbsfune.sbs.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("data-src", ""))
                .Select(x => $"{x.Substring(0, x.LastIndexOf('_'))}.jpg");
        }
    }
}
