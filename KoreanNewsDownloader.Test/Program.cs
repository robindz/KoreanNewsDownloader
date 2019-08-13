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

            await downloader.DownloadArticleImagesAsync("http://www.cbci.co.kr/news/articleView.html?idxno=326582", folder, true);
            await downloader.DownloadArticleImagesAsync("http://cbci.co.kr/news/articleView.html?idxno=326583", folder, true);

            Console.ReadKey();
        }
    }
}
