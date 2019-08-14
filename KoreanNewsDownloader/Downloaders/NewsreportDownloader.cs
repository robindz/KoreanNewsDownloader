using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsreportDownloader : DownloaderBase
    {
        public NewsreportDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.news-report.co.kr", "news-report.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"board_txt_area fr-view\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
