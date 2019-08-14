using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class XportsnewsDownloader : DownloaderBase
    {
        public XportsnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.xportsnews.com", "xportsnews.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"articleView\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
