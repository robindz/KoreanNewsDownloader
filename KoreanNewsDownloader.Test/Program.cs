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

            await downloader.DownloadAsync("http://nc.asiae.co.kr/view.htm?idxno=2019021215491181796", folder);
            await downloader.DownloadAsync("http://stoo.asiae.co.kr/article.php?aid=52011665816", folder);
            await downloader.DownloadAsync("http://tvdaily.asiae.co.kr/read.php3?aid=15433825051417865017", folder);

            Console.ReadKey();
        }
    }
}
