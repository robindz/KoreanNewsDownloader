using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class GetitkDownloader : DownloaderBase
    {
        public GetitkDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.getitk.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"content\"]")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
