using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();
            return images.Select(x => x.Replace("article", "original"));
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => $"{x.Replace("/original.jpg", "").Substring(x.Replace("/original.jpg", "").LastIndexOf('/') + 1)}.jpg");
        }
    }
}
