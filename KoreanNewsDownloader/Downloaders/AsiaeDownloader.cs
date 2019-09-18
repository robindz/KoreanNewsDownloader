using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiaeDownloader : DownloaderBase
    {
        public AsiaeDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "nc.asiae.co.kr", "stoo.asiae.co.kr", "tvdaily.asiae.co.kr", "www.asiae.co.kr", "asiae.co.kr", "leaders.asiae.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"txt_area\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("/1/", "/4/"));
            }
            else if (Uri.Host == HostUrls[1])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"article\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }
            else if (Uri.Host == HostUrls[2])
            {
                return base.GetArticleImages();
            }
            else if (Uri.Host == HostUrls[3])
            {
                return Document.DocumentNode
                    .SelectNodes("//div[@class=\"article_photo\"]/img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }

            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://leaders.asiae.co.kr{x.GetAttributeValue("src", "")}"
                                                                                 : x.GetAttributeValue("src", ""));
        }

        public override string GetArticleTitle()
        {
            if (Uri.Host == HostUrls[1])
            {
                return HttpUtility.HtmlDecode(Document.DocumentNode
                    .Descendants("meta")
                    .First(x => x.GetAttributeValue("property", "") == "og:title")
                    .GetAttributeValue("content", "")).Trim();
            }

            return base.GetArticleTitle();
        }

        public override Encoding GetEncoding()
        {
            if (Uri.Host == HostUrls[0] 
             || Uri.Host == HostUrls[3] 
             || Uri.Host == HostUrls[4])
                return base.GetEncoding();

            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
