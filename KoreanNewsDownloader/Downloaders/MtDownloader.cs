using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MtDownloader : DownloaderBase
    {
        public MtDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "moneys.mt.co.kr", "star.mt.co.kr", "osen.mt.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"textBody\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""))
                    .Select(x => $"{x.Substring(0, x.LastIndexOf('/') - 2)}00{x.Substring(x.LastIndexOf('/'))}");
            }
            else if (Uri.Host == HostUrls[1])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"textBody\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("thumb", "image").Replace(".com/06", ".com"));
            }
            else
            {
                return Document.DocumentNode
                    .SelectNodes("//*[@class=\"view_photo up\"]")
                    .Select(x => x.GetAttributeValue("src", "").Replace("article", "article/original").Replace("_1024x", ""));
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
