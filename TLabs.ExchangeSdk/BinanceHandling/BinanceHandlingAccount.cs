using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.BinanceHandling
{
    public enum BinanceHandlingBot
    {
        Unique = 0, Netter = 10, Squeeze = 20,
    }
    public enum BinanceHandlingApiType
    {
        Team1 = 0, Team2 = 10,
    }

    public class BinanceHandlingAccount
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public string UserId { get; set; }

        public BinanceHandlingApiType ApiType { get; set; }

        public BinanceHandlingBot Bot { get; set; }

        /// <summary>Profit is estimated in this currency</summary>
        public string MainCurrency { get; set; }

        public string ExchangeAccountId { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        /// <summary>Id received from keys handling service</summary>
        public string ServiceKeyId { get; set; }

        /// <summary>When was sent to handling service</summary>
        public DateTimeOffset? DateSent { get; set; }

        /// <summary>Json of response after sending to handling service</summary>
        public string ServiceAddKeyResponse { get; set; }

        /// <summary>Is activated in keys handling service</summary>
        public bool? IsActive { get; set; }

        public List<BinanceHandlingPayment> Payments { get; set; }
        public List<BinanceBalanceSnapshot> Snapshots { get; set; }

        public override string ToString() => $"{nameof(BinanceHandlingAccount)}(Id: {Id}, user:{UserId}, " +
            $"{Bot}-{MainCurrency}, ApiKeys: {ApiKey} - {ApiSecret.Cut(8)}, ServiceKeyId:{ServiceKeyId})";
    }
}
