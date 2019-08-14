using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IlyoseoulDownloader : DownloaderBase
    {
        public IlyoseoulDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.ilyoseoul.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article-view-content-div\"]")
                .Descendants("img")
                .Where(x => !x.GetAttributeValue("src", "").Contains("member"))
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
