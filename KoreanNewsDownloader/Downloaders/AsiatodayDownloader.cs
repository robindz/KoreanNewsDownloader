using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiatodayDownloader : DownloaderBase
    {
        public AsiatodayDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.asiatoday.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri.AbsoluteUri);
        }
    }
}
