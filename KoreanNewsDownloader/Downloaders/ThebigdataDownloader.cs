using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ThebigdataDownloader : DownloaderBase
    {
        public ThebigdataDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.thebigdata.co.kr", "thebigdata.co.kr", "cnews.thebigdata.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectSingleNode("//*[@class=\"txt_article\"]")
                .Descendants("img")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"idx=\d+", "idx=999"))
                .ToList();

            return images;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
