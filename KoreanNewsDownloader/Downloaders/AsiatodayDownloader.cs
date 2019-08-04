using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class AsiatodayDownloader : DownloaderBase
    {
        public AsiatodayDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.asiatoday.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Split('/').Last().Replace("?1", ""));
        }

    }
}
