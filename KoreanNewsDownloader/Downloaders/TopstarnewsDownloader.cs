using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TopstarnewsDownloader : DownloaderBase
    {
        public TopstarnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.topstarnews.net", "topstarnews.net"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = GetOgImageUrl(doc);

            string title = doc.DocumentNode
                .Descendants("meta")
                .Where(x => x.GetAttributeValue("name", "") == "title")
                .FirstOrDefault()
                .GetAttributeValue("content", "");

            if (title.Contains("HD포토") || title.Contains("UHD포토"))
            {
                images = images.Select(x => x.Replace("thumbnail", "photo").Replace("v150", "org").Replace(".jpg", "_org.jpg")).ToList();
            }

            return images;
        }
    }
}
