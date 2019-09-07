using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SegyeDownloader : DownloaderBase
    {
        public SegyeDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "segye.com", "www.segye.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article_txt\"]")
                .Descendants("img")
                .Select(x => $"http:{x.GetAttributeValue("src", "")}");
        }
    }
}
