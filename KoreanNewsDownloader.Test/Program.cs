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
            await downloader.LoadArticleAsync("http://bntnews.hankyung.com/apps/news?popup=0&nid=04&c1=04&c2=04&c3=00&nkey=201812110834233&mode=sub_view");
            await downloader.DownloadArticleImagesAsync(folder, true);
            await downloader.LoadArticleAsync("https://www.hankyung.com/entertainment/article/201904221513H");
            await downloader.DownloadArticleImagesAsync(folder, true);
            await downloader.LoadArticleAsync("http://news.hankyung.com/article/201811053473H");
            await downloader.DownloadArticleImagesAsync(folder, true);
            await downloader.LoadArticleAsync("http://tenasia.hankyung.com/archives/1607731");
            await downloader.DownloadArticleImagesAsync(folder, true);

            Console.ReadKey();
        }
    }
}
