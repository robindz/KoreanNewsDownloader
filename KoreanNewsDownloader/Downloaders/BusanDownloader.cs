using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class BusanDownloader : DownloaderBase
    {
        public BusanDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.busan.com"
            };
            HttpClient = httpClient;
        }
    }
}
