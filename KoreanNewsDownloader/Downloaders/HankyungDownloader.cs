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
            HostUrls = new List<string>
            {
                "bntnews.hankyung.com", "www.hankyung.com", "news.hankyung.com", "tenasia.hankyung.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = new List<string>();

            if (uri.Host == HostUrls[0])
            {
                HtmlDocument doc = await GetDocumentAsync(uri);
                images = doc.DocumentNode
                    .Descendants()
                    .Where(x => x.GetAttributeValue("bgcolor", "") == "#EEEEEE")
                    .Select(x => x.FirstChild.GetAttributeValue("src", ""))
                    .ToList();
            }
            else if (uri.Host == HostUrls[1] || uri.Host == HostUrls[2])
            {
                images = await base.GetImageUrlsAsync(uri);
            }
            else if (uri.Host == HostUrls[3])
            {
                HtmlDocument doc = await GetDocumentAsync(uri);
                images = doc.DocumentNode
                    .Descendants()
                    .Where(x => x.Id.Contains("attachment_"))
                    .Select(x => x.FirstChild.GetAttributeValue("src", "").Substring(0, x.FirstChild.GetAttributeValue("src", "").LastIndexOf("-")) + ".jpg")
                    .ToList();
            }
            
            return images;
        }
    }
}
