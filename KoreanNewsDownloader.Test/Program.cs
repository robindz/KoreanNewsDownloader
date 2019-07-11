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

            await downloader.DownloadAsync(new Uri("https://www.oricon.co.jp/news/2125266/photo/8/"), folder, true);

            Console.ReadKey();
        }
    }
}
