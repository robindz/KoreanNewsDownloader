using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Goodnews1Downloader : DownloaderBase
    {
        public Goodnews1Downloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.goodnews1.com", "goodnews1.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@id=\"newsContents\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
