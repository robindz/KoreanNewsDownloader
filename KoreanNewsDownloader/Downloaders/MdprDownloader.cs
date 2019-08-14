using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MdprDownloader : DownloaderBase
    {
        public MdprDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "mdpr.jp", "www.mdpr.jp"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"outputthumb\"]")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"\?width.*", ""));
        }
    }
}
