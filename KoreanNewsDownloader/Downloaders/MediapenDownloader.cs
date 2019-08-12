using System.Collections.Generic;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class MediapenDownloader : DownloaderBase
    {
        public MediapenDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.mediapen.com", "mediapen.com"
            };
            HttpClient = httpClient;
        }
    }
}
