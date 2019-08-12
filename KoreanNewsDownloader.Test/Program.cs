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

            Console.WriteLine(string.Join("\n", await downloader.GetArticleImagesUrlsAsync("https://mdpr.jp/music/detail/1809786")));

            Console.ReadKey();
        }
    }
}
