using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EdailyDownloader : DownloaderBase
    {
        public EdailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.edaily.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
