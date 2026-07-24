using System;

namespace TLabs.ExchangeSdk.Notificator
{
    public class SendVerificationReminderRequest
    {
        public string Locale { get; set; }

        public DateTimeOffset? ExpiresAt { get; set; }

        public int? MaxAttempts { get; set; }
        
        public int Occurrences { get; set; } = 3;

        public int IntervalDays { get; set; } = 7;
    }
}
