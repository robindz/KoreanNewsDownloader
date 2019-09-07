using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KstyleDownloader : DownloaderBase
    {
        public KstyleDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "news.kstyle.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//*[@class=\"mdMN06ThumbC\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Substring(0, x.GetAttributeValue("src", "").LastIndexOf('/')));
        }
    }
}
