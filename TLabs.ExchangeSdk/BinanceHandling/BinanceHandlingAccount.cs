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
        Unique = 0, Netter = 10,
    }

    public class BinanceHandlingAccount
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public string UserId { get; set; }

        public BinanceHandlingBot Bot { get; set; }

        /// <summary>Profit is estimated in this currency</summary>
        public string MainCurrency { get; set; }

        public string ExchangeAccountId { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        /// <summary>Id received from keys handling service</summary>
        public string ServiceKeyId { get; set; }

        /// <summary>Is activated in keys handling service</summary>
        public bool? IsActive { get; set; }

        public override string ToString() => $"{nameof(BinanceHandlingAccount)}(Id: {Id}, user:{UserId}, " +
            $"{Bot}, ApiKeys: {ApiKey} - {ApiSecret.Cut(8)}, ServiceKeyId:{ServiceKeyId})";
    }
}
