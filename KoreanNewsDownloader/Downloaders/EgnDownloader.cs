using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EgnDownloader : DownloaderBase
    {
        public EgnDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.egn.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("photo"))
                .Select(x => $"http://www.egn.kr{x.GetAttributeValue("src", "")}");
        }
    }
}
