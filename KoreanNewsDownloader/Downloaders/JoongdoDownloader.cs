using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class JoongdoDownloader : DownloaderBase
    {
        public JoongdoDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.joongdo.co.kr", "joongdo.co.kr"
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
