using KoreanNewsDownloader.Downloaders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KoreanNewsDownloader
{
    public class KDownloader
    {
        private readonly IServiceProvider _services;
        private readonly IDownloaderResolver _resolver;
        private IDownloader _downloader;

        public KDownloader()
        {
            _services = ConfigureServices();
            _resolver = _services.GetRequiredService<IDownloaderResolver>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public async Task LoadArticleAsync(string url)
        {
            await LoadArticleAsync(new Uri(url));
        }

        public async Task LoadArticleAsync(Uri uri)
        {
            _downloader = GetDownloader(uri.Host);
            await _downloader.LoadArticleAsync(uri);
        }

        public async Task DownloadArticleImagesAsync(string path, bool overwrite = false)
        {
            await _downloader.DownloadArticleImagesAsync(path, overwrite);
        }

        public IEnumerable<string> GetArticleImages()
        {
            return _downloader.GetArticleImages();
        }

        public string GetArticleTitle()
        {
            return _downloader.GetArticleTitle();
        }

        public string GetHost()
        {
            return _downloader.GetHost();
        }

        private IDownloader GetDownloader(string host)
        {
            return _resolver.GetDownloaderByName(host);
        }

        private ServiceProvider ConfigureServices()
        {
            HttpClientHandler proxyHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer(),
                Proxy = new WebProxy("203.246.112.133", 3128)
            };
            ProxyHttpClient proxyHttpClient = new ProxyHttpClient(proxyHandler);
            proxyHttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");

            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");

            return new ServiceCollection()
                // ProxyHttpClient and HttpClient
                .AddSingleton(proxyHttpClient)
                .AddSingleton(httpClient)
                // RepositoryResolver
                .AddSingleton<IDownloaderResolver, DownloaderResolver>()
                // NewsDownloaders
                .AddSingleton<IDownloader, AjunewsDownloader>()
                .AddSingleton<IDownloader, AsiatodayDownloader>()
                .AddSingleton<IDownloader, HeraldcorpDownloader>()
                .AddSingleton<IDownloader, HankyungDownloader>()
                .AddSingleton<IDownloader, BreaknewsDownloader>()
                .AddSingleton<IDownloader, GetnewsDownloader>()
                .AddSingleton<IDownloader, ThebigdataDownloader>()
                .AddSingleton<IDownloader, DailianDownloader>()
                .AddSingleton<IDownloader, DailypopDownloader>()
                .AddSingleton<IDownloader, DispatchDownloader>()
                .AddSingleton<IDownloader, DtDownloader>()
                .AddSingleton<IDownloader, EdailyDownloader>()
                .AddSingleton<IDownloader, EgnDownloader>()
                .AddSingleton<IDownloader, ImbcDownloader>()
                .AddSingleton<IDownloader, TvingDownloader>()
                .AddSingleton<IDownloader, EtodayDownloader>()
                .AddSingleton<IDownloader, FnnewsDownloader>()
                .AddSingleton<IDownloader, DcinsideDownloader>()
                .AddSingleton<IDownloader, GetitkDownloader>()
                .AddSingleton<IDownloader, IlyoseoulDownloader>()
                .AddSingleton<IDownloader, Inews24Downloader>()
                .AddSingleton<IDownloader, InsightDownloader>()
                .AddSingleton<IDownloader, IntronewsDownloader>()
                .AddSingleton<IDownloader, JoinsDownloader>()
                .AddSingleton<IDownloader, IssuedailyDownloader>()
                .AddSingleton<IDownloader, Joynews24Downloader>()
                .AddSingleton<IDownloader, KookjeDownloader>()
                .AddSingleton<IDownloader, KukinewsDownloader>()
                .AddSingleton<IDownloader, LiveenDownloader>()
                .AddSingleton<IDownloader, NaverDownloader>()
                .AddSingleton<IDownloader, ChosunDownloader>()
                .AddSingleton<IDownloader, MdprDownloader>()
                .AddSingleton<IDownloader, MediasrDownloader>()
                .AddSingleton<IDownloader, MetroseoulDownloader>()
                .AddSingleton<IDownloader, MtDownloader>()
                .AddSingleton<IDownloader, MydailyDownloader>()
                .AddSingleton<IDownloader, NbnnewsDownloader>()
                .AddSingleton<IDownloader, AsiaeDownloader>()
                .AddSingleton<IDownloader, NewdailyDownloader>()
                .AddSingleton<IDownloader, NewsreportDownloader>()
                .AddSingleton<IDownloader, ImaeilDownloader>()
                .AddSingleton<IDownloader, KstyleDownloader>()
                .AddSingleton<IDownloader, TfDownloader>()
                .AddSingleton<IDownloader, News1Downloader>()
                .AddSingleton<IDownloader, NewsinsideDownloader>()
                .AddSingleton<IDownloader, NewspimDownloader>()
                .AddSingleton<IDownloader, NewsshareDownloader>()
                .AddSingleton<IDownloader, NewstomatoDownloader>()
                .AddSingleton<IDownloader, NewsenDownloader>()
                .AddSingleton<IDownloader, NocutnewsDownloader>()
                .AddSingleton<IDownloader, OhmynewsDownloader>()
                .AddSingleton<IDownloader, OriconDownloader>()
                .AddSingleton<IDownloader, OsenDownloader>()
                .AddSingleton<IDownloader, PolinewsDownloader>()
                .AddSingleton<IDownloader, SedailyDownloader>()
                .AddSingleton<IDownloader, SegyeDownloader>()
                .AddSingleton<IDownloader, SeoulDownloader>()
                .AddSingleton<IDownloader, SisajournalDownloader>()
                .AddSingleton<IDownloader, SporbizDownloader>()
                .AddSingleton<IDownloader, DongaDownloader>()
                .AddSingleton<IDownloader, HankookiDownloader>()
                .AddSingleton<IDownloader, KhanDownloader>()
                .AddSingleton<IDownloader, MkDownloader>()
                .AddSingleton<IDownloader, SportsqDownloader>()
                .AddSingleton<IDownloader, SportsseoulDownloader>()
                .AddSingleton<IDownloader, SpotvnewsDownloader>()
                .AddSingleton<IDownloader, HankookilboDownloader>()
                .AddSingleton<IDownloader, StardailynewsDownloader>()
                .AddSingleton<IDownloader, TheceluvDownloader>()
                .AddSingleton<IDownloader, TheviewersDownloader>()
                .AddSingleton<IDownloader, TopstarnewsDownloader>()
                .AddSingleton<IDownloader, TvjDownloader>()
                .AddSingleton<IDownloader, TvreportDownloader>()
                .AddSingleton<IDownloader, UpinewsDownloader>()
                .AddSingleton<IDownloader, Viva100Downloader>()
                .AddSingleton<IDownloader, VopDownloader>()
                .AddSingleton<IDownloader, WebdailyDownloader>()
                .AddSingleton<IDownloader, WikitreeDownloader>()
                .AddSingleton<IDownloader, XportsnewsDownloader>()
                .AddSingleton<IDownloader, Istyle24Downloader>()
                .AddSingleton<IDownloader, KndailyDownloader>()
                .AddSingleton<IDownloader, BusanDownloader>()
                .AddSingleton<IDownloader, GenewsDownloader>()
                .AddSingleton<IDownloader, MediapenDownloader>()
                .AddSingleton<IDownloader, SiminilboDownloader>()
                .AddSingleton<IDownloader, CbciDownloader>()
                .AddSingleton<IDownloader, FashionnDownloader>()
                .AddSingleton<IDownloader, BiztribuneDownloader>()
                .AddSingleton<IDownloader, TenasiaDownloader>()
                .AddSingleton<IDownloader, NewskrDownloader>()
                .AddSingleton<IDownloader, CcdnDownloader>()
                .AddSingleton<IDownloader, JejutwnDownloader>()
                .AddSingleton<IDownloader, EconomytalkDownloader>()
                .AddSingleton<IDownloader, KsilboDownloader>()
                .AddSingleton<IDownloader, WhitepaperDownloader>()
                .AddSingleton<IDownloader, NewscjDownloader>()
                .AddSingleton<IDownloader, SeconomyDownloader>()
                .AddSingleton<IDownloader, SlistDownloader>()
                .AddSingleton<IDownloader, SisamagazineDownloader>()
                .AddSingleton<IDownloader, BetanewsDownloader>()
                .AddSingleton<IDownloader, DaumDownloader>()
                .AddSingleton<IDownloader, KwangjuDownloader>()
                .AddSingleton<IDownloader, FuturekoreaDownloader>()
                .AddSingleton<IDownloader, WowtvDownloader>()
                .AddSingleton<IDownloader, SbsDownloader>()
                .AddSingleton<IDownloader, FntodayDownloader>()
                .AddSingleton<IDownloader, GpkoreaDownloader>()
                .AddSingleton<IDownloader, NewsworksDownloader>()
                .AddSingleton<IDownloader, JoygmDownloader>()
                .AddSingleton<IDownloader, MtnDownloader>()
                .AddSingleton<IDownloader, IncheonilboDownloader>()
                .AddSingleton<IDownloader, Goodnews1Downloader>()
                .AddSingleton<IDownloader, DaejeontodayDownloader>()
                .AddSingleton<IDownloader, KjdailyDownloader>()
                .AddSingleton<IDownloader, SportsworldiDownloader>()
                .AddSingleton<IDownloader, GokoreaDownloader>()
                .AddSingleton<IDownloader, IdjnewsDownloader>()
                .AddSingleton<IDownloader, SeohaenewsDownloader>()
                .AddSingleton<IDownloader, SentvDownloader>()
                .AddSingleton<IDownloader, StraightnewsDownloader>()
                .AddSingleton<IDownloader, AsiatimeDownloader>()
                .AddSingleton<IDownloader, NspnaDownloader>()
                .AddSingleton<IDownloader, BusinesspostDownloader>()
                .AddSingleton<IDownloader, DailysecuDownloader>()
                .AddSingleton<IDownloader, ThetravelnewsDownloader>()
                .AddSingleton<IDownloader, GwbizDownloader>()
                .AddSingleton<IDownloader, HsinewsDownloader>()
                .AddSingleton<IDownloader, ChristiantodayDownloader>()
                .AddSingleton<IDownloader, MedicalworldnewsDownloader>()
                .AddSingleton<IDownloader, KsdailyDownloader>()
                .AddSingleton<IDownloader, KoreabiomedDownloader>()
                .AddSingleton<IDownloader, EtnewsDownloader>()
                .AddSingleton<IDownloader, StarnnewsDownloader>()
                .AddSingleton<IDownloader, MbnDownloader>()
                .BuildServiceProvider();
        }
    }
}
