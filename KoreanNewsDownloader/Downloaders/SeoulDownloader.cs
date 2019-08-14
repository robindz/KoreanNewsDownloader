using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SeoulDownloader : DownloaderBase
    {
        public SeoulDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.seoul.co.kr", "seoul.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"v_photoarea\"]")
                .Descendants("img")
                .Where(x => x.GetAttributeValue("src", "").Contains("upload"))
                .Select(x => $"https:{x.GetAttributeValue("src", "").Replace("_V", "")}");
        }
    }
}
