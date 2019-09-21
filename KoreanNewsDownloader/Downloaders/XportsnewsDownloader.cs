using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class XportsnewsDownloader : DownloaderBase
    {
        public XportsnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.xportsnews.com", "xportsnews.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleView\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
                .Descendants("title")
                .First()
                .InnerText
                .Replace("&amp;quot;", "&quot;"))
                .Trim();
        }
    }
}
