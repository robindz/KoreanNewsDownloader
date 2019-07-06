using KoreanNewsDownloader.Downloaders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KoreanNewsDownloader
{
    public interface IDownloaderResolver
    {
        IDownloader GetDownloaderByName(string name);
    }

    public class DownloaderResolver : IDownloaderResolver
    {
        private readonly IServiceProvider _services;
        public DownloaderResolver(IServiceProvider services)
        {
            _services = services;
        }
        public IDownloader GetDownloaderByName(string host)
        {
            switch (host)
            {
                case "www.ajunews.com": return _services.GetRequiredService<AjunewsDownloader>();
                case "www.asiatoday.co.kr": return _services.GetRequiredService<AsiatodayDownloader>();
                case "biz.heraldcorp.com":
                case "pop.heraldcorp.com": return _services.GetRequiredService<HeraldcorpDownloader>();
                case "bntnews.hankyung.com":
                case "www.hankyung.com":
                case "news.hankyung.com":
                case "tenasia.hankyung.com": return _services.GetRequiredService<HankyungDownloader>();
                case "www.breaknews.com": return _services.GetRequiredService<BreaknewsDownloader>();
                case "www.getnews.co.kr":
                case "cnews.getnews.co.kr": return _services.GetRequiredService<GetnewsDownloader>();
                case "www.thebigdata.co.kr":
                case "cnews.thebigdata.co.kr": return _services.GetRequiredService<ThebigdataDownloader>();
                case "www.dailian.co.kr": return _services.GetRequiredService<DailianDownloader>();
                case "www.dailypop.kr": return _services.GetRequiredService<DailypopDownloader>();
                case "www.dispatch.co.kr": return _services.GetRequiredService<DispatchDownloader>();
            }

            throw new ArgumentException($"No downloader for '{host}' was found.");
        }
    }
}
