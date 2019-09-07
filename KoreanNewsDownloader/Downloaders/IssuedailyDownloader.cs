using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace KoreanNewsDownloader.Downloaders
{
    internal class IssuedailyDownloader : DownloaderBase
    {
        public IssuedailyDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "issuedaily.com", "www.issuedaily.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .Descendants("center")
                .Select(x => x.FirstChild.GetAttributeValue("src", ""));
        }

        public override string GetArticleTitle()
        {
            return HttpUtility.HtmlDecode(Document.DocumentNode
               .Descendants("h2")
               .FirstOrDefault()
               .InnerText);
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
