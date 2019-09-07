﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class JoinsDownloader : DownloaderBase
    {
        public JoinsDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "isplus.live.joins.com", "dcnewsj.joins.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            if (Uri.Host == HostUrls[0])
            {
                return base.GetArticleImages();
            }

            return Document.DocumentNode
                .SelectNodes("//*[@class=\"image\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("data-src", ""));
        }
    }
}
