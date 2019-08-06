using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MdprDownloader : DownloaderBase
    {
        public MdprDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "mdpr.jp", "www.mdpr.jp"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);

            var images = doc.DocumentNode
                .SelectNodes("//*[@class=\"outputthumb\"]")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"\?width.*", ""))
                .ToList();

            return images;
        }
    }
}
