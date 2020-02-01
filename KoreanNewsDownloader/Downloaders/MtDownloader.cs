using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MtDownloader : DownloaderBase
    {
        public MtDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "moneys.mt.co.kr", "star.mt.co.kr", "osen.mt.co.kr", "news.mt.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            try
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
                else if (Uri.Host == HostUrls[2])
                {
                    return Document.DocumentNode
                        .SelectNodes("//*[@class=\"view_photo up\"]")
                        .Select(x => x.GetAttributeValue("src", "").Replace("article", "article/original").Replace("_1024x", ""));
                }
                else
                {
                    return Document.DocumentNode
                        .SelectNodes("//td[@class=\"img\"]/img")
                        .Select(x => x.GetAttributeValue("src", "").StartsWith("//") ? $"https:{x.GetAttributeValue("src", "")}"
                                                                                     : x.GetAttributeValue("src", ""))
                        .Select(x => x.Substring(0, x.IndexOf(".jpg") + 4).Replace("https://thumb.mt.co.kr/06", "http://image.mt.co.kr"));
                }
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public override Encoding GetEncoding()
        {
            if (Uri.Host == HostUrls[0] || Uri.Host == HostUrls[3])
                return Encoding.GetEncoding("EUC-KR");

            return base.GetEncoding();
        }
    }
}
