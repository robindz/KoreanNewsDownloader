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

            await downloader.DownloadArticleImagesAsync(new Uri("http://www.viva100.com/main/view.php?key=20181106010002278"), folder, true);
            await downloader.DownloadArticleImagesAsync(new Uri("http://viva100.com/main/view.php?key=20181106010002278"), folder, true);

            Console.ReadKey();
        }
    }
}
