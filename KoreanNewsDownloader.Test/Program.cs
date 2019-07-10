using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Test
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string folder = @"C:\Users\robin\Desktop\botlog";

            var downloader = new KDownloader();

            await downloader.DownloadAsync("https://www.nocutnews.co.kr/news/5139037", folder);

            Console.ReadKey();
        }
    }
}
