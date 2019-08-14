using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class WikitreeDownloader : DownloaderBase
    {
        public WikitreeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.wikitree.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"wikicon\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("data-src", ""));
        }
    }
}
