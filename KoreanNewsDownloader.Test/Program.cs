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

            await downloader.DownloadAsync("http://moneys.mt.co.kr/news/mwView.php?no=2019021210028052916&outlink=1", folder);
            await downloader.DownloadAsync("http://star.mt.co.kr/stview.php?no=2019042215133513159&outlink=1&ref=https%3A%2F%2Fsearch.daum.net", folder);
            await downloader.DownloadAsync("http://osen.mt.co.kr/article/G1110961803", folder);

            Console.ReadKey();
        }
    }
}
