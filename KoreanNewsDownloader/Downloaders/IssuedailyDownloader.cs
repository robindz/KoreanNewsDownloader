using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IssuedailyDownloader : DownloaderBase
    {
        public IssuedailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.issuedaily.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .Descendants("center")
                .Select(x => x.FirstChild.GetAttributeValue("src", ""));
        }
    }
}
