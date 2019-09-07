using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TopstarnewsDownloader : DownloaderBase
    {
        public TopstarnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.topstarnews.net", "topstarnews.net"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();

            string title = Document.DocumentNode
                .Descendants("meta")
                .Where(x => x.GetAttributeValue("name", "") == "title")
                .FirstOrDefault()
                .GetAttributeValue("content", "");

            if (title.Contains("HD포토") || title.Contains("UHD포토"))
            {
                images = images.Select(x => x.Replace("thumbnail", "photo").Replace("v150", "org").Replace(".jpg", "_org.jpg"));
            }

            return images;
        }
    }
}
