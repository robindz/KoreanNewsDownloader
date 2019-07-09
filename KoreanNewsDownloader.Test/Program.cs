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

            await downloader.DownloadAsync("http://www.newstomato.com/ReadNews.aspx?no=890702", folder);
            await downloader.DownloadAsync("http://newstomato.com/ReadNews.aspx?no=890702", folder, true);

            Console.ReadKey();
        }
    }
}
