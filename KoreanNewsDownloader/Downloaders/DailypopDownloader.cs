using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DailypopDownloader : DownloaderBase
    {
        public DailypopDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dailypop.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .Descendants()
                .Where(x => x.Name == "img" && x.HasClass("content"))
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
