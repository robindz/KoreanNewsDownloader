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

            await downloader.DownloadAsync("http://cnews.getnews.co.kr/view.php?ud=20181129102859399280ed35aa76_16", folder);
            await downloader.DownloadAsync("http://www.getnews.co.kr/view.php?ud=20190519193930687580ed35aa76_16", folder);

            Console.ReadKey();
        }
    }
}
