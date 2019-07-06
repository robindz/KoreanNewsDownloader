using System;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string folder = @"C:\Users\robin\Desktop\botlog";

            var downloader = new KDownloader();

            await downloader.DownloadAsync("http://www.etoday.co.kr/news/section/newsview.php?idxno=1648199", folder);
            await downloader.DownloadAsync("http://enter.etoday.co.kr/view/news_view.php?varAtcId=158112", folder);

            Console.ReadKey();
        }
    }
}
