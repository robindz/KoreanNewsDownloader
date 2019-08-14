using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SportsseoulDownloader : DownloaderBase
    {
        public SportsseoulDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.sportsseoul.com", "sportsseoul.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"news_text\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
