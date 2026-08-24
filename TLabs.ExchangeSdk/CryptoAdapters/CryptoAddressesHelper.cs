using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public static class CryptoAddressesHelper
    {
        private static readonly Regex SolanaAddressRegex = new("^[1-9A-HJ-NP-Za-km-z]{32,44}$", RegexOptions.Compiled);
        private const string BitcoinBase58Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static bool IsValidAddress(string adapterCode, string adapterAddress) => adapterCode switch
        {
            // btc-like
            "btc" => new Regex("^(?:[13]{1}[a-km-zA-HJ-NP-Z1-9]{26,33}|bc1[a-z0-9]{39,59})$").IsMatch(adapterAddress),
            "doge" => new Regex("^D[5-9A-HJ-NP-U]{1}[1-9a-km-zA-HJ-NP-Z]{32}$").IsMatch(adapterAddress),
            "dash" => new Regex("^X[1-9A-HJ-NP-Za-km-z]{33}$").IsMatch(adapterAddress),
            "ltc" => new Regex("^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$").IsMatch(adapterAddress),

            // eth-like
            "eth" => new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterAddress),
            "bsc" => new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterAddress),
            "bini" => new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterAddress),

            // tron-like
            "trx" => new Regex("^T[A-Za-z1-9]{33}$").IsMatch(adapterAddress),
            "orgon" => new Regex("^o[A-Za-z1-9]{33}$").IsMatch(adapterAddress),

            // other
            "ton" => new Regex("^[A-Za-z0-9\\-_]{48}$").IsMatch(adapterAddress),
            "near" => IsValidNearAddress(adapterAddress),
            "sol" => IsValidSolanaAddress(adapterAddress),
            "del" => new Regex("^dx1[ac-hj-np-z0-9]{38}$").IsMatch(adapterAddress),
            "pzm" => new Regex("^PRIZM-[A-Z2-9]{4}-[A-Z2-9]{4}-[A-Z2-9]{4}-[A-Z2-9]{5}$").IsMatch(adapterAddress),
            "umi" => new Regex("^umi1[ac-np-z0-9]{58}$").IsMatch(adapterAddress),
            "tstc" => true,
            _ => false
        };

        public static bool IsValidNearAddress(string adapterAddress)
        {
            if (string.IsNullOrWhiteSpace(adapterAddress))
                return false;
            if (adapterAddress.Length < 2 || adapterAddress.Length > 64)
                return false;
            if (new Regex("^[0-9a-f]{64}$").IsMatch(adapterAddress))
                return true;
            return new Regex("^(([a-z0-9]+[\\-_])*[a-z0-9]+\\.)*([a-z0-9]+[\\-_])*[a-z0-9]+$")
                .IsMatch(adapterAddress);
        }

        /// <summary>
        /// Solana addresses are 32-byte Ed25519 public keys encoded with Bitcoin/Solana Base58
        /// (not Base58Check). A leading alphabet '1' is a 0x00 pad byte.
        /// </summary>
        private static bool IsValidSolanaAddress(string adapterAddress)
        {
            if (adapterAddress == null || !SolanaAddressRegex.IsMatch(adapterAddress))
                return false;
            return TryDecodeBase58ToExactly32Bytes(adapterAddress);
        }

        private static bool TryDecodeBase58ToExactly32Bytes(string input)
        {
            int leadingZeros = 0;
            while (leadingZeros < input.Length && input[leadingZeros] == '1')
                leadingZeros++;

            BigInteger value = BigInteger.Zero;
            for (int i = leadingZeros; i < input.Length; i++)
            {
                int digit = BitcoinBase58Alphabet.IndexOf(input[i]);
                if (digit < 0)
                    return false;
                value = value * 58 + digit;
            }

            byte[] payload = value.IsZero
                ? Array.Empty<byte>()
                : value.ToByteArray(isUnsigned: true, isBigEndian: true);

            return leadingZeros + payload.Length == 32;
        }
    }
}
