using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TheviewersDownloader : DownloaderBase
    {
        public TheviewersDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "theviewers.co.kr", "www.theviewers.co.kr", "viewers.heraldcorp.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                    .SelectNodes("//figure/img")
                    .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://cds.theviewers.co.kr{x.GetAttributeValue("src", "")}"
                                                                                     : x.GetAttributeValue("src", ""));
        }
    }
}
