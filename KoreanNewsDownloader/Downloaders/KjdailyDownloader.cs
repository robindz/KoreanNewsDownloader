using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KjdailyDownloader : DownloaderBase
    {
        public KjdailyDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.kjdaily.com", "kjdaily.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"main_content\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .Where(x => x.Contains("upimages"));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                    .Descendants("meta")
                    .First(x => x.GetAttributeValue("property", "") == "og:title")
                    .GetAttributeValue("content", "")).Trim();
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
