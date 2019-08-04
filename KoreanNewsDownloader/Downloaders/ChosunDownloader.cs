using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ChosunDownloader : DownloaderBase
    {
        public ChosunDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "sports.chosun.com", "m.sportschosun.com"
            };
            HttpClient = httpClient;
        }
        /*
        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }*/
    }
}
