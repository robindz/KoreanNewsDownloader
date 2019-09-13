using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SeohaenewsDownloader : DownloaderBase
    {
        public SeohaenewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.seohaenews.net", "seohaenews.net"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"cnt_view news_body_area\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/data/") ? $"http://www.seohaenews.net{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }
    }
}
