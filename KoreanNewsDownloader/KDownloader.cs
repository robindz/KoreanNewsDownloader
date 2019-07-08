using KoreanNewsDownloader.Downloaders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader
{
    public class KDownloader
    {
        private readonly IServiceProvider _services;
        private readonly IDownloaderResolver _resolver;

        public KDownloader()
        {
            _services = ConfigureServices();
            _resolver = _services.GetRequiredService<IDownloaderResolver>();
        }

        public async Task DownloadAsync(string url, string filePath, bool overwrite = false)
        {
            await DownloadAsync(new Uri(url), filePath, overwrite);
        }

        public async Task DownloadAsync(Uri uri, string filePath, bool overwrite = false)
        {
            var downloader = GetDownloader(uri.Host);
            await downloader.DownloadAsync(uri, filePath, overwrite);
        }

        private IDownloader GetDownloader(string host)
        {
            return _resolver.GetDownloaderByName(host);
        }

        private ServiceProvider ConfigureServices()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer(),
            };

            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");

            return new ServiceCollection()
                // HttpClient
                .AddSingleton(httpClient)
                // RepositoryResolver
                .AddSingleton<IDownloaderResolver, DownloaderResolver>()
                // NewsDownloaders
                .AddTransient<AjunewsDownloader>()
                .AddTransient<AsiatodayDownloader>()
                .AddTransient<HeraldcorpDownloader>()
                .AddTransient<HankyungDownloader>()
                .AddTransient<BreaknewsDownloader>()
                .AddTransient<GetnewsDownloader>()
                .AddTransient<ThebigdataDownloader>()
                .AddTransient<DailianDownloader>()
                .AddTransient<DailypopDownloader>()
                .AddTransient<DispatchDownloader>()
                .AddTransient<DtDownloader>()
                .AddTransient<EdailyDownloader>()
                .AddTransient<EgnDownloader>()
                .AddTransient<ImbcDownloader>()
                .AddTransient<TvingDownloader>()
                .AddTransient<EtodayDownloader>()
                .AddTransient<DaumDownloader>()
                .AddTransient<FnnewsDownloader>()
                .AddTransient<DcinsideDownloader>()
                .AddTransient<GetitkDownloader>()
                .AddTransient<IlyoseoulDownloader>()
                .AddTransient<Inews24Downloader>()
                .AddTransient<InsightDownloader>()
                .AddTransient<IntronewsDownloader>()
                .AddTransient<JoinsDownloader>()
                .AddTransient<IssuedailyDownloader>()
                .AddTransient<Joynews24Downloader>()
                .AddTransient<KookjeDownloader>()
                .AddTransient<KukinewsDownloader>()
                .AddTransient<LiveenDownloader>()
                .AddTransient<NaverDownloader>()
                .AddTransient<ChosunDownloader>()
                .AddTransient<MdprDownloader>()
                .BuildServiceProvider();
        }
    }
}
