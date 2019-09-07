using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AjunewsDownloader : DownloaderBase
    {
        public AjunewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.ajunews.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode.SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants()
                .Where(x => x.Name == "img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
