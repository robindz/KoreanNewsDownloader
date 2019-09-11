using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    public class GpkoreaDownloader : DownloaderBase
    {
        public GpkoreaDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.gpkorea.com", "gpkorea.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://www.gpkorea.com{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}
