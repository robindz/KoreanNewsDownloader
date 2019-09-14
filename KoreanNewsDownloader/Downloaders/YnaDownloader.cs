using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class YnaDownloader : DownloaderBase
    {
        public YnaDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.yna.co.kr", "yna.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleWrap\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("//") ? $"https:{x.GetAttributeValue("src", "")}"
                                                                             : x.GetAttributeValue("src", ""));
        }
    }
}
