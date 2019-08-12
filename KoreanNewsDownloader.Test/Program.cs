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

            await downloader.DownloadArticleImagesAsync(new Uri("http://www.siminilbo.co.kr/news/newsview.php?ncode=179524305975223"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("http://siminilbo.co.kr/news/newsview.php?ncode=179524305975223"), folder, true);

            Console.ReadKey();
        }
    }
}
