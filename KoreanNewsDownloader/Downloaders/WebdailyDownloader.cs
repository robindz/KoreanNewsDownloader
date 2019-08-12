using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            var images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => Regex.Replace(x, @"idx=\d+", "idx=999")).ToList();
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
