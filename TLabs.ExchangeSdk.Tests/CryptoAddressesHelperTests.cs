using NUnit.Framework;
using TLabs.ExchangeSdk.CryptoAdapters;

namespace TLabs.ExchangeSdk.Tests;

public class CryptoAddressesHelperTests
{
    [TestCase("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef")]
    [TestCase("alice.near")]
    [TestCase("usdt.tether-token.near")]
    [TestCase("binibit-usdt.roundarena5463.testnet")]
    public void IsValidNearAddress_accepts_implicit_and_named(string address)
    {
        Assert.That(CryptoAddressesHelper.IsValidNearAddress(address), Is.True);
        Assert.That(CryptoAddressesHelper.IsValidAddress("near", address), Is.True);
    }

    [TestCase(" alice.near")]
    [TestCase("alice.near ")]
    [TestCase(" alice.near ")]
    [TestCase("foo--bar.near")]
    [TestCase("foo__bar.near")]
    [TestCase("-alice.near")]
    [TestCase("alice.near.")]
    [TestCase("A.NEAR")]
    public void IsValidNearAddress_rejects_whitespace_and_invalid_named_ids(string address)
    {
        Assert.That(CryptoAddressesHelper.IsValidNearAddress(address), Is.False);
        Assert.That(CryptoAddressesHelper.IsValidAddress("near", address), Is.False);
    }
}
