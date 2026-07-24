using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Notificator
{
    public class VerificationReminderDispatchResponse
    {
        public int UnverifiedUsersCount { get; set; }

        public int TargetUsersCount { get; set; }

        public int EligibleUsersCount { get; set; }

        public int EnqueuedCount { get; set; }

        public int ScheduledCount { get; set; }

        public int SkippedWithoutEmailCount { get; set; }

        public int SkippedDeletedCount { get; set; }

        public int SkippedLockedCount { get; set; }

        public List<Guid> DispatchIds { get; set; } = new List<Guid>();
    }
}
