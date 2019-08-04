using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DcinsideDownloader : DownloaderBase
    {
        public DcinsideDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "gall.dcinside.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"writing_view_box\"]")
                .Descendants("img")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"dcimg\d{1}", "dcimg8"))
                .ToList();

            return images;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => $"{x.Substring(x.LastIndexOf("=") + 1)}.jpg");
        }
    }
}
