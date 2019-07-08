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

            await downloader.DownloadAsync("http://www.kukinews.com/news/article.html?no=616048", folder);
            await downloader.DownloadAsync("http://www.kukinews.com/news/article.html?no=616048&mode=orig&rvw_no=", folder, true);

            Console.ReadKey();
        }
    }
}
