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

            await downloader.DownloadAsync("http://www.dt.co.kr/contents.html?article_no=2019042202109965035019&ref=daum", folder);

            Console.ReadKey();
        }
    }
}
