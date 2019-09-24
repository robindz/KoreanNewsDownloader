using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace KoreanNewsDownloader.Downloaders
{
    internal class DongaDownloader : DownloaderBase
    {
        public DongaDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient)
        {
            HostUrls = new List<string>
            {
                "sports.donga.com"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            var result = Document.DocumentNode
                .SelectSingleNode("//*[@id=\"article_body\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""))
                .ToList();

            if (!result.Any())
            {
                result.Add(Document.DocumentNode.SelectSingleNode("//meta[@name=\"twitter:image:src\"]").GetAttributeValue("content", ""));

                string baseUrl = $"https://dimg.donga.com/wps/SPORTS/IMAGE/YYYY/MM/DD/";
                string date = string.Empty;
                var matches = Regex.Match(Uri.AbsoluteUri, @"^.+all\/(?<date>\d+)");
                if (matches.Groups["date"].Success)
                    date = matches.Groups["date"].Value;

                baseUrl = baseUrl.Replace("YYYY", date.Substring(0, 4))
                                 .Replace("MM",   date.Substring(4, 2))
                                 .Replace("DD",   date.Substring(6, 2));

                var ids = Document.DocumentNode
                    .SelectNodes("//wpsimage")
                    .Select(x => x.GetAttributeValue("gid", ""));

                foreach (string id in ids)
                {
                    result.Add($"{baseUrl}{id}.jpg");
                }
            }

            return result;
        }
    }
}
