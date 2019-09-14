using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ThetravelnewsDownloader : DownloaderBase
    {
        public ThetravelnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.thetravelnews.co.kr", "thetravelnews.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/a")
                .Select(x => x.GetAttributeValue("href", ""));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                .Descendants("h1")
                .FirstOrDefault()
                .InnerText).Trim();
        }
    }
}
