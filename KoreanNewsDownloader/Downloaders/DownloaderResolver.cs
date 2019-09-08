using KoreanNewsDownloader.Downloaders;
using KoreanNewsDownloader.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
            IDownloader downloader = _services.GetServices<IDownloader>().Where(x => x.HostUrls.Contains(host)).FirstOrDefault();

            if (downloader == null)
            {
                throw new UnsupportedHostException($"{host} is not a supported host.");
            }

            return downloader;
        }
    }
}
