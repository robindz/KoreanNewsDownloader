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

            await downloader.DownloadArticleImagesAsync("http://www.biztribune.co.kr/news/articleView.html?idxno=220259", folder, true);
            await downloader.DownloadArticleImagesAsync("http://biztribune.co.kr/news/articleView.html?idxno=220259", folder, true);

            Console.ReadKey();
        }
    }
}
