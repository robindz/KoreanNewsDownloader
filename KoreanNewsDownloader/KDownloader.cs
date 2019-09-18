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

        public KDownloader(WebProxy proxy)
        {
            _services = ConfigureServices(proxy);
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

        private ServiceProvider ConfigureServices(WebProxy proxy)
        {
            HttpClientHandler proxyHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer(),
                Proxy = proxy
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
                .AddTransient<IDownloader, AjunewsDownloader>()
                .AddTransient<IDownloader, AsiatodayDownloader>()
                .AddTransient<IDownloader, HeraldcorpDownloader>()
                .AddTransient<IDownloader, HankyungDownloader>()
                .AddTransient<IDownloader, BreaknewsDownloader>()
                .AddTransient<IDownloader, GetnewsDownloader>()
                .AddTransient<IDownloader, ThebigdataDownloader>()
                .AddTransient<IDownloader, DailianDownloader>()
                .AddTransient<IDownloader, DailypopDownloader>()
                .AddTransient<IDownloader, DispatchDownloader>()
                .AddTransient<IDownloader, DtDownloader>()
                .AddTransient<IDownloader, EdailyDownloader>()
                .AddTransient<IDownloader, EgnDownloader>()
                .AddTransient<IDownloader, ImbcDownloader>()
                .AddTransient<IDownloader, TvingDownloader>()
                .AddTransient<IDownloader, EtodayDownloader>()
                .AddTransient<IDownloader, FnnewsDownloader>()
                .AddTransient<IDownloader, DcinsideDownloader>()
                .AddTransient<IDownloader, GetitkDownloader>()
                .AddTransient<IDownloader, IlyoseoulDownloader>()
                .AddTransient<IDownloader, Inews24Downloader>()
                .AddTransient<IDownloader, InsightDownloader>()
                .AddTransient<IDownloader, IntronewsDownloader>()
                .AddTransient<IDownloader, JoinsDownloader>()
                .AddTransient<IDownloader, IssuedailyDownloader>()
                .AddTransient<IDownloader, Joynews24Downloader>()
                .AddTransient<IDownloader, KookjeDownloader>()
                .AddTransient<IDownloader, KukinewsDownloader>()
                .AddTransient<IDownloader, LiveenDownloader>()
                .AddTransient<IDownloader, NaverDownloader>()
                .AddTransient<IDownloader, ChosunDownloader>()
                .AddTransient<IDownloader, MdprDownloader>()
                .AddTransient<IDownloader, MediasrDownloader>()
                .AddTransient<IDownloader, MetroseoulDownloader>()
                .AddTransient<IDownloader, MtDownloader>()
                .AddTransient<IDownloader, MydailyDownloader>()
                .AddTransient<IDownloader, NbnnewsDownloader>()
                .AddTransient<IDownloader, AsiaeDownloader>()
                .AddTransient<IDownloader, NewdailyDownloader>()
                .AddTransient<IDownloader, NewsreportDownloader>()
                .AddTransient<IDownloader, ImaeilDownloader>()
                .AddTransient<IDownloader, KstyleDownloader>()
                .AddTransient<IDownloader, TfDownloader>()
                .AddTransient<IDownloader, News1Downloader>()
                .AddTransient<IDownloader, NewsinsideDownloader>()
                .AddTransient<IDownloader, NewspimDownloader>()
                .AddTransient<IDownloader, NewsshareDownloader>()
                .AddTransient<IDownloader, NewstomatoDownloader>()
                .AddTransient<IDownloader, NewsenDownloader>()
                .AddTransient<IDownloader, NocutnewsDownloader>()
                .AddTransient<IDownloader, OhmynewsDownloader>()
                .AddTransient<IDownloader, OriconDownloader>()
                .AddTransient<IDownloader, OsenDownloader>()
                .AddTransient<IDownloader, PolinewsDownloader>()
                .AddTransient<IDownloader, SedailyDownloader>()
                .AddTransient<IDownloader, SegyeDownloader>()
                .AddTransient<IDownloader, SeoulDownloader>()
                .AddTransient<IDownloader, SisajournalDownloader>()
                .AddTransient<IDownloader, SporbizDownloader>()
                .AddTransient<IDownloader, DongaDownloader>()
                .AddTransient<IDownloader, HankookiDownloader>()
                .AddTransient<IDownloader, KhanDownloader>()
                .AddTransient<IDownloader, MkDownloader>()
                .AddTransient<IDownloader, SportsqDownloader>()
                .AddTransient<IDownloader, SportsseoulDownloader>()
                .AddTransient<IDownloader, SpotvnewsDownloader>()
                .AddTransient<IDownloader, HankookilboDownloader>()
                .AddTransient<IDownloader, StardailynewsDownloader>()
                .AddTransient<IDownloader, TheceluvDownloader>()
                .AddTransient<IDownloader, TheviewersDownloader>()
                .AddTransient<IDownloader, TopstarnewsDownloader>()
                .AddTransient<IDownloader, TvjDownloader>()
                .AddTransient<IDownloader, TvreportDownloader>()
                .AddTransient<IDownloader, UpinewsDownloader>()
                .AddTransient<IDownloader, Viva100Downloader>()
                .AddTransient<IDownloader, VopDownloader>()
                .AddTransient<IDownloader, WebdailyDownloader>()
                .AddTransient<IDownloader, WikitreeDownloader>()
                .AddTransient<IDownloader, XportsnewsDownloader>()
                .AddTransient<IDownloader, Istyle24Downloader>()
                .AddTransient<IDownloader, KndailyDownloader>()
                .AddTransient<IDownloader, BusanDownloader>()
                .AddTransient<IDownloader, GenewsDownloader>()
                .AddTransient<IDownloader, MediapenDownloader>()
                .AddTransient<IDownloader, SiminilboDownloader>()
                .AddTransient<IDownloader, CbciDownloader>()
                .AddTransient<IDownloader, FashionnDownloader>()
                .AddTransient<IDownloader, BiztribuneDownloader>()
                .AddTransient<IDownloader, TenasiaDownloader>()
                .AddTransient<IDownloader, NewskrDownloader>()
                .AddTransient<IDownloader, CcdnDownloader>()
                .AddTransient<IDownloader, JejutwnDownloader>()
                .AddTransient<IDownloader, EconomytalkDownloader>()
                .AddTransient<IDownloader, KsilboDownloader>()
                .AddTransient<IDownloader, WhitepaperDownloader>()
                .AddTransient<IDownloader, NewscjDownloader>()
                .AddTransient<IDownloader, SeconomyDownloader>()
                .AddTransient<IDownloader, SlistDownloader>()
                .AddTransient<IDownloader, SisamagazineDownloader>()
                .AddTransient<IDownloader, BetanewsDownloader>()
                .AddTransient<IDownloader, DaumDownloader>()
                .AddTransient<IDownloader, KwangjuDownloader>()
                .AddTransient<IDownloader, FuturekoreaDownloader>()
                .AddTransient<IDownloader, WowtvDownloader>()
                .AddTransient<IDownloader, SbsDownloader>()
                .AddTransient<IDownloader, FntodayDownloader>()
                .AddTransient<IDownloader, GpkoreaDownloader>()
                .AddTransient<IDownloader, NewsworksDownloader>()
                .AddTransient<IDownloader, JoygmDownloader>()
                .AddTransient<IDownloader, MtnDownloader>()
                .AddTransient<IDownloader, IncheonilboDownloader>()
                .AddTransient<IDownloader, Goodnews1Downloader>()
                .AddTransient<IDownloader, DaejeontodayDownloader>()
                .AddTransient<IDownloader, KjdailyDownloader>()
                .AddTransient<IDownloader, SportsworldiDownloader>()
                .AddTransient<IDownloader, GokoreaDownloader>()
                .AddTransient<IDownloader, IdjnewsDownloader>()
                .AddTransient<IDownloader, SeohaenewsDownloader>()
                .AddTransient<IDownloader, SentvDownloader>()
                .AddTransient<IDownloader, StraightnewsDownloader>()
                .AddTransient<IDownloader, AsiatimeDownloader>()
                .AddTransient<IDownloader, NspnaDownloader>()
                .AddTransient<IDownloader, BusinesspostDownloader>()
                .AddTransient<IDownloader, DailysecuDownloader>()
                .AddTransient<IDownloader, ThetravelnewsDownloader>()
                .AddTransient<IDownloader, GwbizDownloader>()
                .AddTransient<IDownloader, HsinewsDownloader>()
                .AddTransient<IDownloader, ChristiantodayDownloader>()
                .AddTransient<IDownloader, MedicalworldnewsDownloader>()
                .AddTransient<IDownloader, KsdailyDownloader>()
                .AddTransient<IDownloader, KoreabiomedDownloader>()
                .AddTransient<IDownloader, EtnewsDownloader>()
                .AddTransient<IDownloader, StarnnewsDownloader>()
                .AddTransient<IDownloader, MbnDownloader>()
                .AddTransient<IDownloader, KoreatimesDownloader>()
                .AddTransient<IDownloader, PurpressDownloader>()
                .AddTransient<IDownloader, KmibDownloader>()
                .AddTransient<IDownloader, YtnDownloader>()
                .AddTransient<IDownloader, NanumnewsDownloader>()
                .AddTransient<IDownloader, JjanDownloader>()
                .AddTransient<IDownloader, GooddailynewsDownloader>()
                .AddTransient<IDownloader, KadoDownloader>()
                .AddTransient<IDownloader, BeyondpostDownloader>()
                .AddTransient<IDownloader, YnaDownloader>()
                .AddTransient<IDownloader, DizzoDownloader>()
                .AddTransient<IDownloader, CnbnewsDownloader>()
                .AddTransient<IDownloader, SmloungeDownloader>()
                .AddTransient<IDownloader, JoongdoDownloader>()
                .AddTransient<IDownloader, SisafocusDownloader>()
                .AddTransient<IDownloader, StarjnDownloader>()
                .AddTransient<IDownloader, KyeonginDownloader>()
                .AddTransient<IDownloader, Interview365Downloader>()
                .AddTransient<IDownloader, KidstvnewsDownloader>()
                .AddTransient<IDownloader, CcreviewDownloader>()
                .AddTransient<IDownloader, CoinreadersDownloader>()
                .AddTransient<IDownloader, PpnewsDownloader>()
                .AddTransient<IDownloader, IworldtodayDownloader>()
                .AddTransient<IDownloader, MilDownloader>()
                .AddTransient<IDownloader, InsightkoreaDownloader>()
                .AddTransient<IDownloader, FamtimesDownloader>()
                .AddTransient<IDownloader, Rpm9Downloader>()
                .AddTransient<IDownloader, SeoulwireDownloader>()
                .AddTransient<IDownloader, HorsebizDownloader>()
                .AddTransient<IDownloader, IminjuDownloader>()
                .AddTransient<IDownloader, PluskoreaDownloader>()
                .AddTransient<IDownloader, ObsnewsDownloader>()
                .AddTransient<IDownloader, PulsenewsDownloader>()
                .BuildServiceProvider();
        }
    }
}
