using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SentvDownloader : DownloaderBase
    {
        public SentvDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.sentv.co.kr", "sentv.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"img-area\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                    .Descendants("meta")
                    .First(x => x.GetAttributeValue("property", "") == "og:title")
                    .GetAttributeValue("content", "")).Trim();
        }
    }
}
