using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IssuedailyDownloader : DownloaderBase
    {
        public IssuedailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.issuedaily.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants("center")
                .Select(x => x.FirstChild.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}
