using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MbnDownloader : DownloaderBase
    {
        public MbnDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "star.mbn.co.kr", "www.mbn.co.kr", "mbn.co.kr", "mbnmoney.mbn.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[3])
            {
                return Document.DocumentNode
                    .SelectNodes("//td[@class=\"Img\"]/img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }

            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"newsViewArea\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
