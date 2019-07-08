using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiaeDownloader : DownloaderBase
    {
        public AsiaeDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "nc.asiae.co.kr", "stoo.asiae.co.kr", "tvdaily.asiae.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            IList<string> images = new List<string>();
            HtmlDocument doc = await GetDocumentAsync(uri);

            if (uri.Host == HostUrls[0])
            {
                images = doc.DocumentNode
                    .SelectSingleNode("//*[@id=\"txt_area\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("/1/", "/4/"))
                    .ToList();
            }
            else if (uri.Host == HostUrls[1])
            {
                images = doc.DocumentNode
                    .SelectSingleNode("//*[@id=\"article\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""))
                    .ToList();
            }
            else
            {
                images = GetOgImage(doc);
            }

            return images;
        }
    }
}
