using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class VopDownloader : DownloaderBase
    {
        public VopDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.vop.co.kr", "vop.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                .SelectNodes("//*[@id=\"vopimageAD\"]")
                .Select(x => (x.GetAttributeValue("src", "").Contains("marked") ? x.GetAttributeValue("src", "")
                                                                                : x.GetAttributeValue("src", "").Insert(x.GetAttributeValue("src", "")
                                                                                   .LastIndexOf('/'), "/marked")).Replace("http:", "https:"))
                .ToList();

            return images;
        }
    }
}
