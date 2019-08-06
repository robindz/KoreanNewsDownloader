using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IntronewsDownloader : DownloaderBase
    {
        public IntronewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.intronews.net"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            var images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => x.Replace("thumbnail", "photo").Replace("_v150", "")).ToList();
        }
    }
}
