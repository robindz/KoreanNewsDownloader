using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Inews24Downloader : DownloaderBase
    {
        public Inews24Downloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.inews24.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .Descendants("figure")
                .Where(x => !x.HasClass("related"))
                .Select(x => x.FirstChild.GetAttributeValue("src", ""));
        }
    }
}
