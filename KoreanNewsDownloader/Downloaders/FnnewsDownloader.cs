using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class FnnewsDownloader : DownloaderBase
    {
        public FnnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "star.fnnews.com", "www.fnnews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
