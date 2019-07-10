using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NewsenDownloader : DownloaderBase
    {
        public NewsenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.newsen.com", "newsen.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
