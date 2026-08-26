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
        /// (not Base58Check). A leading alphabet '1' is a 0x00 pad byte. Dest wallets must be
        /// on-curve (ATA PDAs are off-curve and rejected).
        /// </summary>
        private static bool IsValidSolanaAddress(string adapterAddress)
        {
            if (adapterAddress == null || !SolanaAddressRegex.IsMatch(adapterAddress))
                return false;
            if (!TryDecodeBase58To32Bytes(adapterAddress, out byte[] keyBytes))
                return false;
            return IsOnCurve(keyBytes);
        }

        /// <summary>
        /// Bitcoin/Solana Base58 decode to exactly 32 bytes. Leading alphabet '1' becomes 0x00 pads.
        /// </summary>
        private static bool TryDecodeBase58To32Bytes(string input, out byte[] bytes)
        {
            bytes = null;
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

            if (leadingZeros + payload.Length != 32)
                return false;

            bytes = new byte[32];
            Buffer.BlockCopy(payload, 0, bytes, 32 - payload.Length, payload.Length);
            return true;
        }

        // Field arithmetic copied from Solnet.Wallet 8.7.0 Ed25519Extensions.IsOnCurve (MIT).
        // Original Ed25519 Java port by Hans Wolff / k3d3, public domain.
        // https://github.com/bmresearch/Solnet/blob/v8.7.0/src/Solnet.Wallet/Utilities/Ed25519Extensions.cs
        private static bool IsOnCurve(byte[] key)
        {
            BigInteger y = new BigInteger(key) & Un;
            BigInteger x = RecoverX(y);
            return IsOnCurve(x, y);
        }

        private static BigInteger ExpMod(BigInteger number, BigInteger exponent, BigInteger modulo)
        {
            if (exponent.Equals(BigInteger.Zero))
                return BigInteger.One;
            BigInteger t = BigInteger.Pow(ExpMod(number, exponent / Two, modulo), 2).Mod(modulo);
            if (!exponent.IsEven)
            {
                t *= number;
                t = t.Mod(modulo);
            }
            return t;
        }

        private static BigInteger Inv(BigInteger x) => ExpMod(x, Qm2, Q);

        private static BigInteger RecoverX(BigInteger y)
        {
            BigInteger y2 = y * y;
            BigInteger xx = (y2 - 1) * Inv(D * y2 + 1);
            BigInteger x = ExpMod(xx, Qp3 / Eight, Q);
            if (!(x * x - xx).Mod(Q).Equals(BigInteger.Zero))
                x = (x * I).Mod(Q);
            if (!x.IsEven)
                x = Q - x;
            return x;
        }

        private static bool IsOnCurve(BigInteger x, BigInteger y)
        {
            BigInteger xx = x * x;
            BigInteger yy = y * y;
            BigInteger dxxyy = D * yy * xx;
            return (yy - xx - dxxyy - 1).Mod(Q).Equals(BigInteger.Zero);
        }

        private static readonly BigInteger Q =
            BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819949");
        private static readonly BigInteger Qm2 =
            BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819947");
        private static readonly BigInteger Qp3 =
            BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819952");
        private static readonly BigInteger D =
            BigInteger.Parse("-4513249062541557337682894930092624173785641285191125241628941591882900924598840740");
        private static readonly BigInteger I =
            BigInteger.Parse("19681161376707505956807079304988542015446066515923890162744021073123829784752");
        private static readonly BigInteger Un =
            BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564819967");
        private static readonly BigInteger Two = new BigInteger(2);
        private static readonly BigInteger Eight = new BigInteger(8);
    }

    internal static class SolanaBigIntegerHelpers
    {
        internal static BigInteger Mod(this BigInteger num, BigInteger modulo)
        {
            var result = num % modulo;
            return result < 0 ? result + modulo : result;
        }
    }
}
