using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Farming.Dtos
{
    public class UserInfo
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public string? UserName { get; set; }
        public string? TgUserName { get; set; }
        public long TgUserId { get; set; }
        public DateTimeOffset DateRegistered { get; set; }
        public int RewardDayCount { get; set; }

        public decimal Balance { get; set; }
        public int ReferralsCount { get; set; }
    }
}
