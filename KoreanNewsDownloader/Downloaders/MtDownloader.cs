using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MtDownloader : DownloaderBase
    {
        public MtDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "moneys.mt.co.kr", "star.mt.co.kr", "osen.mt.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = new List<string>();
            HtmlDocument doc = await GetDocumentAsync(uri);

            if (uri.Host == HostUrls[0])
            {
                images = doc.DocumentNode
                    .SelectSingleNode("//*[@id=\"textBody\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""))
                    .Select(x => $"{x.Substring(0, x.LastIndexOf('/') - 2)}00{x.Substring(x.LastIndexOf('/'))}")
                    .ToList();
            }
            else if (uri.Host == HostUrls[1])
            {
                images = doc.DocumentNode
                    .SelectSingleNode("//*[@id=\"textBody\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("thumb", "image").Replace(".com/06", ".com"))
                    .ToList();
            }
            else
            {
                images = doc.DocumentNode
                    .SelectNodes("//*[@class=\"view_photo up\"]")
                    .Select(x => x.GetAttributeValue("src", "").Replace("article", "article/original").Replace("_1024x", ""))
                    .ToList();
            }

            return images;
        }
    }
}
