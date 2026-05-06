using System;

namespace TLabs.ExchangeSdk.MobileApps
{
    public class MobileAppVersionDto
    {
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public string ApkUrl { get; set; }
        public long ApkSize { get; set; }
        public DateTimeOffset ReleasedAt { get; set; }
    }
}
