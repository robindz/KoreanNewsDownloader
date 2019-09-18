using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MilDownloader : DownloaderBase
    {
        public MilDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "kookbang.dema.mil.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"content_body\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/newspaper/") ? $"http://kookbang.dema.mil.kr{x.GetAttributeValue("src", "")}"
                                                                                      : x.GetAttributeValue("src", ""));
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
