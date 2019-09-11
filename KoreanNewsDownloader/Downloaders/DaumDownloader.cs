using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DaumDownloader : DownloaderBase
    {
        public DaumDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "news.v.daum.net"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectNodes("//figure/*/img")
                .Select(x => $"{x.GetAttributeValue("src", "")}?original");
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            images = base.GetFilenames(images);
            return images.Select(x => x.Replace("?original", string.Empty));
        }
    }
}
