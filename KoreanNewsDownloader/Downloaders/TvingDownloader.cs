using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TvingDownloader : DownloaderBase
    {
        public TvingDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "enews24.tving.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
