using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KukinewsDownloader : DownloaderBase
    {
        public KukinewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.kukinews.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
