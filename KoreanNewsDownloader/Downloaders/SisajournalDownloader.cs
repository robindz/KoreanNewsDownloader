using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SisajournalDownloader : DownloaderBase
    {
        public SisajournalDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.sisajournal.com", "sisajournal.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => $"http://www.sisajournal.com{x.GetAttributeValue("src", "")}");
        }
    }
}
