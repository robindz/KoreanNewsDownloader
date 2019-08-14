using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class UpinewsDownloader : DownloaderBase
    {
        public UpinewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.upinews.kr", "upinews.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"viewConts\"]")
                .Descendants("img")
                .Select(x => $"http://www.upinews.kr/{x.GetAttributeValue("src", "")}");
        }
    }
}
