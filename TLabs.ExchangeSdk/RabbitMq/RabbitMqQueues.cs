using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.RabbitMq
{
    public static class RabbitMqQueues
    {
        public const string AffiliateProfit = "affiliate-profit";
        public const string AffiliateOrderFilled = "affiliate-order-filled";
        public const string BountyRecords = "bounty-records";
        public const string Notifications = "notifications"; // Notificator
    }
}
