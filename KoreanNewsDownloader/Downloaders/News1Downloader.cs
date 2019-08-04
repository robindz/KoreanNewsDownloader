using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class News1Downloader : DownloaderBase
    {
        public News1Downloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.news1.kr", "news1.kr"
            };
            HttpClient = httpClient;
        }
        /*
        public override async Task<IList<string>> GetImagesAsync(Uri uri)
        {
            var images = await GetOgImageAsync(uri);

            images = images.Select(x => x.Replace("article", "original")).ToList();

            return images;
        }*/
    }
}
