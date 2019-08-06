using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class ChosunDownloader : DownloaderBase
    {
        public ChosunDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "sports.chosun.com", "m.sportschosun.com"
            };
            HttpClient = httpClient;
        }
    }
}
