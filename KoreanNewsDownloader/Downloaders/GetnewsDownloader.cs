using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class GetnewsDownloader : DownloaderBase
    {
        public GetnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.getnews.co.kr", "cnews.getnews.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
