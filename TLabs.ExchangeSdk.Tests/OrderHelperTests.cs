using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLabs.ExchangeSdk.Currencies;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.Tests
{
    public class OrderHelperTests
    {
        private List<CurrencyPair> Pairs = new List<CurrencyPair>
        {
            new CurrencyPair("ETH_BTC") { DigitsAmount = 8, DigitsPrice = 8 },
            new CurrencyPair("BTC_USDT") { DigitsAmount = 8, DigitsPrice = 8 },
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task OrderExtensions()
        {
            var order = new Order(true, "BTC_USDT", 40000, 1);
            Assert.AreEqual("USDT", order.GetSentCurrency());
            Assert.AreEqual("BTC", order.GetReceivedCurrency());
            Assert.AreEqual(40000, order.GetSentAmount());
            Assert.AreEqual(1, order.GetReceivedAmount());
        }

        [Test]
        public async Task BidCreatedCorrectly()
        {
            var orderResult = OrderHelper.GetOrderByDirection(Pairs, "USDT", "BTC", 40000, 1);
            Assert.True(orderResult.Succeeded);
            var order = orderResult.Data;
            Assert.AreEqual("BTC_USDT", order.CurrencyPairCode);
            Assert.AreEqual(true, order.IsBid);
            Assert.AreEqual(1, order.Amount);
            Assert.AreEqual(40000, order.Price);
        }

        [Test]
        public async Task AskCreatedCorrectly()
        {
            var orderResult = OrderHelper.GetOrderByDirection(Pairs, "BTC", "USDT", 1, 40000);
            Assert.True(orderResult.Succeeded);
            var order = orderResult.Data;
            Assert.AreEqual("BTC_USDT", order.CurrencyPairCode);
            Assert.AreEqual(false, order.IsBid);
            Assert.AreEqual(1, order.Amount);
            Assert.AreEqual(40000, order.Price);
        }

        [Test]
        public async Task BidCreatedFromPriceCorrectly()
        {
            var orderResult = OrderHelper.GetOrderByDirection(Pairs, "USDT", "BTC", 40000, null, price: 40000);
            Assert.True(orderResult.Succeeded);
            var order = orderResult.Data;
            Assert.AreEqual("BTC_USDT", order.CurrencyPairCode);
            Assert.AreEqual(true, order.IsBid);
            Assert.AreEqual(1, order.Amount);
            Assert.AreEqual(40000, order.Price);
        }

        [Test]
        public async Task NoCurrencyPair()
        {
            var orderResult = OrderHelper.GetOrderByDirection(Pairs, "DASH", "BTC", 40000, 1);
            Assert.False(orderResult.Succeeded);
        }

        [Test]
        public async Task NoAmounts()
        {
            var orderResult = OrderHelper.GetOrderByDirection(Pairs, "DASH", "BTC", 40000, null);
            Assert.False(orderResult.Succeeded);
        }
    }
}
