using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class WebdailyDownloader : DownloaderBase
    {
        public WebdailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.webdaily.co.kr", "webdaily.co.kr"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();
            return images.Select(x => Regex.Replace(x, @"idx=\d+", "idx=999"));
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
