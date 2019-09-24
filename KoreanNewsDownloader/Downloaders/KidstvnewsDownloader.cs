using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class KidstvnewsDownloader : DownloaderBase
    {
        public KidstvnewsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "www.kidstvnews.co.kr", "kidstvnews.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            try
            {
                return Document.DocumentNode
                .SelectNodes("//figure/img")
                .Select(x => Regex.Replace(x.GetAttributeValue("src", ""), @"idx=\d+", "idx=999"));
            }
            catch (Exception) { }
            return new List<string>();
        }
    }
}
