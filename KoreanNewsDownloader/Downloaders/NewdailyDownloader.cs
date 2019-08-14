using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewdailyDownloader : DownloaderBase
    {
        public NewdailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newdaily.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"imgframe sm-image-c\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
