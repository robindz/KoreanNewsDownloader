using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DaumDownloader : DownloaderBase
    {
        public DaumDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "entertain.v.daum.net"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.Name == "meta" && x.GetAttributeValue("property", "") == "twitter:image")
                .Select(x => x.GetAttributeValue("content", ""))
                .ToList();

            return images;
        }
    }
}
