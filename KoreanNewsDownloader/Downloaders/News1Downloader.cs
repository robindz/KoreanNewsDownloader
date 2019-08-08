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
        
        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = new List<string>();

            if (uri.AbsoluteUri.Contains("view"))
            {
                uri = new Uri(uri.AbsoluteUri.Replace("view", "details").Replace("&80", ""));
                images = await base.GetImageUrlsAsync(uri);
                return images.Select(x => x.Replace("article", "original")).ToList();
            }

            images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => x.Replace("article", "original")).ToList();
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => $"{x.Replace("/original.jpg", "").Substring(x.Replace("/original.jpg", "").LastIndexOf('/') + 1)}.jpg");
        }
    }
}
