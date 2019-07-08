using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiatodayDownloader : DownloaderBase
    {
        public AsiatodayDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.asiatoday.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
