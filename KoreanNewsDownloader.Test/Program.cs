using KoreanNewsDownloader.Downloaders;
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

            await downloader.DownloadAsync("http://www.breaknews.com/sub_read.html?uid=665014", folder);

            Console.ReadKey();
        }
    }
}
