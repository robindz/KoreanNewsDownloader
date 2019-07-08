using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Inews24Downloader : DownloaderBase
    {
        public Inews24Downloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.inews24.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .Descendants("figure")
                .Where(x => !x.HasClass("related"))
                .Select(x => x.FirstChild.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}
