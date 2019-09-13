using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NspnaDownloader : DownloaderBase
    {
        public NspnaDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.nspna.com", "nspna.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
               .SelectSingleNode("//*[@id=\"CmAdContent\"]")
               .Descendants("img")
               .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
