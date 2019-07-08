using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class BreaknewsDownloader : DownloaderBase
    {
        public BreaknewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.breaknews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            IList<string> images = new List<string>();
            HtmlDocument doc = await GetDocumentAsync(uri);

            string image = doc.DocumentNode
                .SelectSingleNode("//*[@id=\"img_pop_view\"]")
                .GetAttributeValue("src", "");
            images.Add(image);

            return images;
        }
    }
}
