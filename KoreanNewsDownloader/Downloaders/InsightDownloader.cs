using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class InsightDownloader : DownloaderBase
    {
        public InsightDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.insight.co.kr", "photo.insight.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"news-article-memo\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
