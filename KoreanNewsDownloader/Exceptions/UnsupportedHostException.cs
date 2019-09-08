using System;

namespace KoreanNewsDownloader.Exceptions
{
    public class UnsupportedHostException : Exception
    {
        public UnsupportedHostException(string message) : base(message) { }
    }
}
