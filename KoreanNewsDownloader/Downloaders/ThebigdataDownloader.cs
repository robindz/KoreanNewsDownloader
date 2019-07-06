using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ThebigdataDownloader : DownloaderBase
    {
        public ThebigdataDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>()
            {
                "www.thebigdata.co.kr", "cnews.thebigdata.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            return await GetOgImageAsync(uri);
        }
    }
}
