using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"txt_area\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", "").Replace("/1/", "/4/"));
            }
            else if (Uri.Host == HostUrls[1])
            {
                return Document.DocumentNode
                    .SelectSingleNode("//*[@id=\"article\"]")
                    .Descendants("img")
                    .Select(x => x.GetAttributeValue("src", ""));
            }
            else
            {
                return base.GetArticleImages();
            }
        }
    }
}
