using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class FashionnDownloader : DownloaderBase
    {
        public FashionnDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.fashionn.com", "fashionn.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"view_body\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
