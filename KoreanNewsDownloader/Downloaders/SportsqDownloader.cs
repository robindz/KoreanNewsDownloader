using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SportsqDownloader : DownloaderBase
    {
        public SportsqDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.sportsq.co.kr", "sportsq.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/div/img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
