using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Rpm9Downloader : DownloaderBase
    {
        public Rpm9Downloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.rpm9.com", "rpm9.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
