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
                "news.v.daum.net", "entertain.v.daum.net"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return Document.DocumentNode
                    .SelectNodes("//figure/*/img")
                    .Select(x => $"{x.GetAttributeValue("src", "")}?original");
            }

            return Document.DocumentNode
                .SelectNodes("//img[@class=\"thumb_g_article\"]")
                .Select(x => x.GetAttributeValue("src", ""))
                .Select(x => x.Contains("?fname=") ? x.Substring(x.IndexOf("?fname=") + 7) : x);
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            images = base.GetFilenames(images);

            if (Uri.Host == HostUrls[1])
                return images;

            return images.Select(x => x.Replace("?original", string.Empty));
        }
    }
}
