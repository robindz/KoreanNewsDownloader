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

            await downloader.DownloadAsync("http://www.dailian.co.kr/news/view/789623", folder);

            Console.ReadKey();
        }
    }
}
