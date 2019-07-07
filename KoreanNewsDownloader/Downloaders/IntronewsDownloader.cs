using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IntronewsDownloader : DownloaderBase
    {
        public IntronewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.intronews.net"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.Name == "meta" && x.GetAttributeValue("property", "") == "og:image")
                .Select(x => x.GetAttributeValue("content", "").Replace("thumbnail", "photo").Replace("_v150", ""))
                .ToList();

            return images;
        }
    }
}
