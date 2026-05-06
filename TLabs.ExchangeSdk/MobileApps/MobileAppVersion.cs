using System;

namespace TLabs.ExchangeSdk.MobileApps
{
    public class MobileAppVersion
    {
        public int Id { get; set; }
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public long ApkSize { get; set; }
        public DateTimeOffset ReleasedAt { get; set; }
    }
}
