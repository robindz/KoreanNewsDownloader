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

            await downloader.DownloadAsync("https://post.naver.com/viewer/postView.nhn?volumeNo=18717990&memberNo=29747755", folder);
            await downloader.DownloadAsync("https://m.post.naver.com/viewer/postView.nhn?volumeNo=19894147&memberNo=22171331", folder);

            Console.ReadKey();
        }
    }
}
