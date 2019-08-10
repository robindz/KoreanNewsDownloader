using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SisajournalDownloader : DownloaderBase
    {
        public SisajournalDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.sisajournal.com", "sisajournal.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => $"http://www.sisajournal.com{x.GetAttributeValue("src", "")}")
                .ToList();

            return images;
        }
    }
}
