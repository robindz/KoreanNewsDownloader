using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankookilboDownloader : DownloaderBase
    {
        public HankookilboDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "star.hankookilbo.com", "www.hankookilbo.com", "hankookilbo.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/*/img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
