using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DispatchDownloader : DownloaderBase
    {
        public DispatchDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.dispatch.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .Descendants()
                .Where(x => x.Name == "img" && x.GetAttributeValue("src", "").Contains("uploads"))
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
