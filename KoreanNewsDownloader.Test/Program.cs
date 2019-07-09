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

            await downloader.DownloadAsync("http://news1.kr/photos/details/?3402915", folder);
            await downloader.DownloadAsync("http://www.news1.kr/photos/details/?3402915", folder, true);

            Console.ReadKey();
        }
    }
}
