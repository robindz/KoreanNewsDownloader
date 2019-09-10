using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    public class SlistDownloader : DownloaderBase
    {
        public SlistDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.slist.kr", "slist.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://www.slist.kr{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
