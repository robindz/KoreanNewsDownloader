using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KhanDownloader : DownloaderBase
    {
        public KhanDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "sports.khan.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Replace("l_", ""));
        }
    }
}
