using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DailianDownloader : DownloaderBase
    {
        public DailianDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.dailian.co.kr"
            };
            HttpClient = httpClient;
        }
        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
