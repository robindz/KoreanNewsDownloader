using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KookjeDownloader : DownloaderBase
    {
        public KookjeDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.kookje.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.AbsoluteUri.Contains("newsbody"))
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@class=\"news_article\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }

            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"thumbs\"]")
                .Descendants("img")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), "/S", "/L"));
        }

        public override string GetArticleTitle()
        {
            if (Uri.AbsoluteUri.Contains("newsbody"))
            {
                return base.GetArticleTitle();
            }

            return HttpUtility.HtmlDecode(Document.DocumentNode
               .Descendants("h2")
               .LastOrDefault()
               .InnerText).Trim();
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
