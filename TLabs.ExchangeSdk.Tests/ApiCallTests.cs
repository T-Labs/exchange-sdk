using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;
using TLabs.ExchangeSdk.LiquidityImport;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.Tests
{
    public class ApiCallTests
    {
        private string _currencyPairCode = "ETH_BTC";

        [SetUp]
        public void Setup()
        {
            FlurlExtensions.InitFlurl(Constants.GatewayUrl);
        }

        [Test]
        public async Task OrderExtensions()
        {
            var clientLiquidityMain = new ClientLiquidityMain();

            // will throw error if action doesn't exist or service isn't launched
            var r1 = await clientLiquidityMain.IsCurrencyPairActive(_currencyPairCode);
            var r2 = await clientLiquidityMain.GetActiveCurrencyPairs(Exchange.Binance);
        }
    }
}
