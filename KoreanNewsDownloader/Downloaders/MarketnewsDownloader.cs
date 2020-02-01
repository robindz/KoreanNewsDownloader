using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MarketnewsDownloader : DownloaderBase
    {
        public MarketnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.marketnews.co.kr", "marketnews.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", string.Empty));
        }
    }
}
