using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankookilboDownloader : DownloaderBase
    {
        public HankookilboDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "star.hankookilbo.com"
            };
            HttpClient = httpClient;
        }
    }
}
