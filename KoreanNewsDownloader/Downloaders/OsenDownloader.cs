using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class OsenDownloader : DownloaderBase
    {
        public OsenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.osen.co.kr", "osen.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                    .SelectNodes("//*[@class=\"view_photo up\"]")
                    .Select(x => x.GetAttributeValue("src", "").Replace("article", "article/original").Replace("_1024x", ""));
        }
    }
}
