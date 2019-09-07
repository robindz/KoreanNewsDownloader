using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ImbcDownloader : DownloaderBase
    {
        public ImbcDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "enews.imbc.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                    .SelectSingleNode("//*[@class=\"ent-cont\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
