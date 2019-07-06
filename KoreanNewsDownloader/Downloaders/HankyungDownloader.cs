using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankyungDownloader : DownloaderBase
    {
        public HankyungDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "bntnews.hankyung.com", "www.hankyung.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri.AbsoluteUri);

            var images = doc.DocumentNode
                .Descendants()
                .Where(x => x.GetAttributeValue("bgcolor", "") == "#EEEEEE")
                .Select(x => x.FirstChild.GetAttributeValue("src", ""))
                .ToList();

            return images;
        }
    }
}
