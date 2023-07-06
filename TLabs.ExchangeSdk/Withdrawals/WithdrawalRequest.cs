using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class WithdrawalRequest
    {
        public WithdrawalType WithdrawalType { get; set; }

        public string UserId { get; set; }

        /// <summary> Blockchain address for withdrawal </summary>
        [Required]
        public string Address { get; set; }

        /// <summary> Public key of node's address, required for Prizm (PZM) </summary>
        public string AddressPublicKey { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        /// <summary>
        /// Only used with WithdrawalType.AdvCashBankCard
        /// </summary>
        public WithdrawalBankCard BankCard { get; set; }

        /// <summary>
        /// Google Authenticator Code
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// Code sent to email
        /// </summary>
        public string EmailAuthCode { get; set; }

        /// <summary>Only used in cash withdrawals</summary>
        public string PublicId { get; set; } = null;

        public override string ToString() => $"{nameof(WithdrawalRequest)}({UserId}, {Amount} {CurrencyCode}, " +
            $"to {Address}, emailAuthCode:{EmailAuthCode}, gAuth:{AuthCode} {(BankCard == null ? "" : $", {BankCard}")})";
    }
}
