using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankyungDownloader : DownloaderBase
    {
        public HankyungDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "bntnews.hankyung.com", "www.hankyung.com", "news.hankyung.com", "tenasia.hankyung.com", "hei.hankyung.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return Document.DocumentNode
                    .Descendants()
                    .Where(x => x.GetAttributeValue("bgcolor", "") == "#EEEEEE")
                    .Select(x => x.FirstChild.GetAttributeValue("src", ""));
            }
            else if (Uri.Host == HostUrls[1] || Uri.Host == HostUrls[2])
            {
                return base.GetArticleImages();
            }
            else if (Uri.Host == HostUrls[3])
            {
                return Document.DocumentNode
                    .Descendants()
                    .Where(x => x.Id.Contains("attachment_"))
                    .Select(x => x.FirstChild.GetAttributeValue("src", "").Substring(0, x.FirstChild.GetAttributeValue("src", "").LastIndexOf("-")) + ".jpg");
            }
            else
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@class=\"articleImg txtC\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }
        }

        public override Encoding GetEncoding()
        {
            if (Uri.Host == HostUrls[0])
                return Encoding.GetEncoding("EUC-KR");

            return base.GetEncoding();
        }
    }
}
