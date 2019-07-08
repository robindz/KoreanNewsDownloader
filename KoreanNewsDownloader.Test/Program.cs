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

            await downloader.DownloadAsync("http://www.metroseoul.co.kr/news/newsview?newscd=2018101600195", folder);

            Console.ReadKey();
        }
    }
}
