using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ChosunDownloader : DownloaderBase
    {
        public ChosunDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "sports.chosun.com", "m.sportschosun.com", "news.chosun.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[2])
            {
                return Document.DocumentNode
                    .SelectNodes("//figure/img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }

            return base.GetArticleImages();
        }

        public override Encoding GetEncoding()
        {
            if (Uri.Host == HostUrls[0])
                return Encoding.GetEncoding("EUC-KR");

            return base.GetEncoding();
        }
    }
}
