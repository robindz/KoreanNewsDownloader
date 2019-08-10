using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class SedailyDownloader : DownloaderBase
    {
        public SedailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.sedaily.com", "sedaily.com"
            };
            HttpClient = httpClient;
        }
    }
}
