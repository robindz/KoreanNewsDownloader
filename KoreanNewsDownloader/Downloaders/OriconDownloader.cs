using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class OriconDownloader : DownloaderBase
    {
        public OriconDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.oricon.co.jp"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"centering-image\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("SHIFT-JIS");
        }
    }
}
