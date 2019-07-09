using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsinsideDownloader : DownloaderBase
    {
        public NewsinsideDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsinside.kr", "newsinside.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
