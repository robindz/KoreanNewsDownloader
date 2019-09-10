using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    public class NewscjDownloader : DownloaderBase
    {
        public NewscjDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.newscj.com", "newscj.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => x.GetAttributeValue("src", ""));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                .Descendants("meta")
                .First(x => x.GetAttributeValue("name", "") == "title")
                .GetAttributeValue("content", "")).Trim();
        }
    }
}
