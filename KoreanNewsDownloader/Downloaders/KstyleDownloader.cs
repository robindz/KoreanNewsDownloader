using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KstyleDownloader : DownloaderBase
    {
        public KstyleDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "news.kstyle.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"mdMN06ThumbC\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", "").Substring(0, x.GetAttributeValue("src", "").LastIndexOf('/')))
                .ToList();

            return images;
        }
    }
}
