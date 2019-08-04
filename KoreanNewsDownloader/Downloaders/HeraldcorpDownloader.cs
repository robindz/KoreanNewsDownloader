using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HeraldcorpDownloader : DownloaderBase
    {
        public HeraldcorpDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "biz.heraldcorp.com", "pop.heraldcorp.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            IList<string> images = await base.GetImageUrlsAsync(uri);

            if (uri.Host == HostUrls[1])
            {
                images = images.Select(x => Regex.Replace(x, @"idx=\d+", "idx=999")).ToList();
            }

            return images;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
