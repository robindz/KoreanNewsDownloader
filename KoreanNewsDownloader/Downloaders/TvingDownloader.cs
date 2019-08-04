using System.Collections.Generic;
using System.Net.Http;

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
    }
}
