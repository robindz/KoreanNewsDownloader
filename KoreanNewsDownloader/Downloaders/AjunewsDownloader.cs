using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AjunewsDownloader : DownloaderBase
    {
        public AjunewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.ajunews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode.SelectSingleNode("//*[@id=\"articleBody\"]")
                .Descendants()
                .Where(x => x.Name == "img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}
