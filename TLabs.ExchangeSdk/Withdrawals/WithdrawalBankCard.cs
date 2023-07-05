using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class WithdrawalBankCard
    {
        [Key]
        public Guid WithdrawalId { get; set; }

        [ForeignKey("WithdrawalId")]
        public Withdrawal Withdrawal { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Range(1, 12)]
        public int ExpiryMonth { get; set; }

        [Range(20, 99)]
        public int ExpiryYear { get; set; }

        /// <summary>
        /// Phone of card holder
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// First and lastname of card holder
        /// </summary>
        public string Name { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? DateBirthday { get; set; }

        public override string ToString() => $"{nameof(WithdrawalBankCard)}({CardNumber.Substring(0, 8)}, " +
            $"{ExpiryMonth}/{ExpiryYear}, {Name}, {City}, {Country}, {DateBirthday?.ToString("yyyy-MM-dd")})";
    }
}
