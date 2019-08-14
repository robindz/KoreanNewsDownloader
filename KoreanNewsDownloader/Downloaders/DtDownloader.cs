using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DtDownloader : DownloaderBase
    {
        public DtDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dt.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"img_center\"]/img")
                .Select(x => x.GetAttributeValue("src", "").Substring(0, x.GetAttributeValue("src", "").LastIndexOf("?")));
        }
    }
}
