using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class HeraldcorpDownloader : DownloaderBase
    {
        public HeraldcorpDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "biz.heraldcorp.com", "pop.heraldcorp.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var images = base.GetArticleImages();

            if (Uri.Host == HostUrls[1])
            {
                images = images.Select(x => Regex.Replace(x, @"idx=\d+", "idx=999"));
            }

            return images;
        }

        public override IEnumerable<string> GetFilenames(IEnumerable<string> images)
        {
            return images.Select(x => x.Substring(x.LastIndexOf("=") + 1));
        }
    }
}
