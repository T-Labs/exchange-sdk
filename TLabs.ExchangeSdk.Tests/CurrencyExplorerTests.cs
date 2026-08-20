using NUnit.Framework;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Tests
{
    public class CurrencyExplorerTests
    {
        private const string Sig = "5wJbGqE9YqKqYqKqYqKqYqKqYqKqYqKqYqKqYqKqYqKq";

        [Test]
        public void GetTxUrl_Sol_RawSignature()
        {
            Assert.That(CurrencyExplorer.GetTxUrl("sol", Sig),
                Is.EqualTo($"https://solscan.io/tx/{Sig}"));
        }

        [Test]
        public void GetTxUrl_Sol_PlatformDepositTxId_StripsCurrencySuffix()
        {
            Assert.That(CurrencyExplorer.GetTxUrl("sol", Sig + ":USDC"),
                Is.EqualTo(CurrencyExplorer.GetTxUrl("sol", Sig)));
        }

        [Test]
        public void GetTxUrl_Sol_UsdtAndSolSuffixes_StripToSameUrl()
        {
            string raw = CurrencyExplorer.GetTxUrl("sol", Sig);
            Assert.That(CurrencyExplorer.GetTxUrl("sol", Sig + ":USDT"), Is.EqualTo(raw));
            Assert.That(CurrencyExplorer.GetTxUrl("sol", Sig + ":SOL"), Is.EqualTo(raw));
        }

        [Test]
        public void GetTxUrl_Sol_WithdrawalIdHasNoSuffix()
        {
            string url = CurrencyExplorer.GetTxUrl("sol", Sig);
            Assert.That(url, Is.EqualTo($"https://solscan.io/tx/{Sig}"));
            Assert.That(url, Does.Not.Contain(":SOL"));
            Assert.That(url, Does.Not.Contain(":USDC"));
            Assert.That(url, Does.Not.Contain(":USDT"));
        }

        [Test]
        public void GetAddressUrl_Sol()
        {
            const string wallet = "9WzDXwBbmkg8ZTbNMqUxvQRAyrZzDsGYdLVL9zYtAWWM";
            Assert.That(CurrencyExplorer.GetAddressUrl("sol", wallet),
                Is.EqualTo($"https://solscan.io/account/{wallet}"));
        }
    }
}
