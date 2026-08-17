using NUnit.Framework;
using TLabs.ExchangeSdk.Withdrawals;

namespace TLabs.ExchangeSdk.Tests
{
    public class WithdrawalRequestTests
    {
        [Test]
        public void ToString_DoesNotIncludeOtpCodes()
        {
            var request = new WithdrawalRequest
            {
                UserId = "user-1",
                Amount = 10.5m,
                CurrencyCode = "USDT",
                Address = "TXYZ123",
                EmailAuthCode = "123456",
                AuthCode = "654321",
            };

            var text = request.ToString();

            Assert.That(text, Does.Contain("user-1"));
            Assert.That(text, Does.Contain("10.5"));
            Assert.That(text, Does.Contain("USDT"));
            Assert.That(text, Does.Contain("TXYZ123"));
            Assert.That(text, Does.Not.Contain("emailAuthCode"));
            Assert.That(text, Does.Not.Contain("gAuth"));
            Assert.That(text, Does.Not.Contain("123456"));
            Assert.That(text, Does.Not.Contain("654321"));
        }
    }
}
