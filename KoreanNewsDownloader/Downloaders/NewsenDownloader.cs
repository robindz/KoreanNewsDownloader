using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsenDownloader : DownloaderBase
    {
        public NewsenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsen.com", "newsen.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@id=\"artImg\"]")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
