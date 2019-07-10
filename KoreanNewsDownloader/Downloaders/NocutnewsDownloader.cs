using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class NocutnewsDownloader : DownloaderBase
    {
        public NocutnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.nocutnews.co.kr", "nocutnews.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
