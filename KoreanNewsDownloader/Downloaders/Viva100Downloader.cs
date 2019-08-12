using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class Viva100Downloader : DownloaderBase
    {
        public Viva100Downloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.viva100.com", "viva100.com"
            };
            HttpClient = httpClient;
        }
    }
}
