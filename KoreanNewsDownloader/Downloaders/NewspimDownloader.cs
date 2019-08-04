using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewspimDownloader : DownloaderBase
    {
        public NewspimDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newspim.com", "newspim.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"news_contents\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Replace("_w", ""))
                .ToList();

            return images;
        }
    }
}
