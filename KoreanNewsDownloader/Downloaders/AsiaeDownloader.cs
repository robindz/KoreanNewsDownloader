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
                "nc.asiae.co.kr", "stoo.asiae.co.kr", "tvdaily.asiae.co.kr"
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
            else
            {
                return base.GetArticleImages();
            }
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
            if (Uri.Host == HostUrls[0])
                return base.GetEncoding();

            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
