using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HankookiDownloader : DownloaderBase
    {
        public HankookiDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "sports.hankooki.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            var images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => x.Replace("photo/", "original/")).ToList();
        }
    }
}
