using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EtodayDownloader : DownloaderBase
    {
        public EtodayDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "enter.etoday.co.kr", "www.etoday.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
