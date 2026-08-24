using NUnit.Framework;
using TLabs.ExchangeSdk.CryptoAdapters;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Tests;

    public class CryptoAddressesHelperTests
    {
        // 32 zero bytes — Bitcoin/Solana Base58 leading '1' is a 0x00 pad.
        private const string SystemProgram = "11111111111111111111111111111111";
        // Canonical Tokenkeg program id (32-byte pubkey, 44-char base58).
        private const string Tokenkeg = "TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA";
        private const string MainnetUsdc = "EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v";
        private const string MainnetUsdt = "Es9vMFrzaCERmJfrF4H2FYD4KCoNkY11McCe8BenwNYB";
        private const string DevnetUsdc = "4zMMC9srt5Ri5X14GAgXhaHii3GnPAEERYPJgZJDncDU";
        // Typical on-curve wallet pubkeys (32-byte decode).
        private const string TypicalWalletA = "9WzDXwBbmkg8ZTbNMqUxvQRAyrZzDsGYdLVL9zYtAWWM";
        private const string TypicalWalletB = "7xKXtg2CW87d97TXJSDpbD5jBkheTqA83TZRuJosgAsU";

        [Test]
        public void Sol_Known32BytePubkey_IsValid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", Tokenkeg), Is.True);
        }

        [Test]
        public void Sol_PubkeyStartingWith1_IsValid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", SystemProgram), Is.True);
        }

        [TestCase(MainnetUsdc)]
        [TestCase(MainnetUsdt)]
        [TestCase(DevnetUsdc)]
        [TestCase(TypicalWalletA)]
        [TestCase(TypicalWalletB)]
        public void Sol_TypicalAddresses_AreValid(string address)
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", address), Is.True);
        }

        [Test]
        public void Sol_32CharBase58ThatDecodesToWrongLength_IsInvalid()
        {
            var tooFewBytes = new string('2', 32);
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", tooFewBytes), Is.False);
        }

        [Test]
        public void Sol_44CharBase58ThatDecodesToWrongLength_IsInvalid()
        {
            var tooManyBytes = new string('z', 44);
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", tooManyBytes), Is.False);
        }

        [Test]
        public void Sol_ShorterThan32Chars_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", new string('1', 31)), Is.False);
        }

        [Test]
        public void Sol_LongerThan44Chars_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", Tokenkeg + "1"), Is.False);
        }

        [TestCase("0")]
        [TestCase("O")]
        [TestCase("I")]
        [TestCase("l")]
        public void Sol_AmbiguousBase58Chars_AreInvalid(string badChar)
        {
            // Bitcoin/Solana Base58 alphabet omits 0, O, I, l. Regex must reject them
            // before decode (they would also fail IndexOf).
            string mutated = badChar + Tokenkeg.Substring(1);
            Assert.That(mutated.Length, Is.EqualTo(Tokenkeg.Length));
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", mutated), Is.False);
        }

        [Test]
        public void Sol_TonAddress_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol",
                "UQBhG8VrdcOYZW77pbFv9NnzLIBnrwYRWAtiIQu2nhb2BoS5"), Is.False);
        }

        [Test]
        public void Sol_EthAddress_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol",
                "0x742d35Cc6634C0532925a3b844Bc9e7595f0bEb0"), Is.False);
        }

        [Test]
        public void Sol_Empty_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", ""), Is.False);
            Assert.That(CryptoAddressesHelper.IsValidAddress("sol", null), Is.False);
        }

        [Test]
        public void WrongAdapter_SolAddress_IsInvalid()
        {
            Assert.That(CryptoAddressesHelper.IsValidAddress("ton", Tokenkeg), Is.False);
            Assert.That(CryptoAddressesHelper.IsValidAddress("eth", Tokenkeg), Is.False);
        }

        [Test]
        public void AdapterSol_IsRegistered()
        {
            Assert.That(Adapter.AdapterSol.Code, Is.EqualTo("sol"));
            Assert.That(Adapter.AdapterSol.Name, Is.EqualTo("Solana"));
            Assert.That(Adapter.AdapterSol.MainCurrencyCode, Is.EqualTo("SOL"));
            Assert.That(Adapter.DefaultAdapters, Does.Contain(Adapter.AdapterSol));
        }

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
