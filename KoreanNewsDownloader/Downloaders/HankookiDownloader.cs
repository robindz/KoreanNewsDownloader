using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankookiDownloader : DownloaderBase
    {
        public HankookiDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "sports.hankooki.com", "daily.hankooki.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                var images = base.GetArticleImages();
                return images.Select(x => x.Replace("arch/photo/", "arch/original/"));
            }

            return Document.DocumentNode
                .SelectNodes("//*[@class=\"gisaimg\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
