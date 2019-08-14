using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NbnnewsDownloader : DownloaderBase
    {
        public NbnnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.nbnnews.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("/news/photo"))
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
