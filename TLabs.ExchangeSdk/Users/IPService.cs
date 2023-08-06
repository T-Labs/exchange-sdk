using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TLabs.ExchangeSdk.Users
{
    public interface IIPService
    {
        string GetRequestIP(bool tryUseXForwardHeader = true);
    }

    public class IPService : IIPService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<IPService> _logger;

        public IPService(IHttpContextAccessor httpContextAccessor,
            ILogger<IPService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public string GetRequestIP(bool tryUseXForwardHeader = true)
        {
            string ip = null;

            // todo support new "Forwarded" header (2014) https://en.wikipedia.org/wiki/X-Forwarded-For

            // X-Forwarded-For (csv list):  Using the First entry in the list seems to work
            // for 99% of cases however it has been suggested that a better (although tedious)
            // approach might be to read each IP from right to left and use the first public IP.
            // http://stackoverflow.com/a/43554000/538763
            //
            if (tryUseXForwardHeader)
            {
                ip = SplitCsv(GetHeaderValueAs<string>("X-Forwarded-For")).FirstOrDefault();
            }

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (string.IsNullOrWhiteSpace(ip) && _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
            {
                ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");
            }

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (string.IsNullOrWhiteSpace(ip))
            {
                _logger.LogWarning("Unable to determine caller's IP");
            }

            return ip;
        }

        private T GetHeaderValueAs<T>(string headerName)
        {
            var headers = _httpContextAccessor.HttpContext?.Request?.Headers;
            if (headers == null)
            {
                if (headers.TryGetValue(headerName, out StringValues values))
                {
                    string rawValues = values.ToString();   // writes out as Csv when there are multiple.
                    if (!string.IsNullOrEmpty(rawValues))
                        return (T)Convert.ChangeType(values.ToString(), typeof(T));
                }
            }
            return default;
        }

        private static List<string> SplitCsv(string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
            {
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();
            }

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }
    }
}
