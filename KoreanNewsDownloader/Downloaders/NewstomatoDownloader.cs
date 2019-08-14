using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewstomatoDownloader : DownloaderBase
    {
        public NewstomatoDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newstomato.com", "newstomato.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"rns_text\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
