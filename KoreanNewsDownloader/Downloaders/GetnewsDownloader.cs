using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class GetnewsDownloader : DownloaderBase
    {
        public GetnewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.getnews.co.kr", "cnews.getnews.co.kr"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = await base.GetImageUrlsAsync(uri);
            return images.Select(x => Regex.Replace(x, @"idx=\d+", "idx=999")).ToList();
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
