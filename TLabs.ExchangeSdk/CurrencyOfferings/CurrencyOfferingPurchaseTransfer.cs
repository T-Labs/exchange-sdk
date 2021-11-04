using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public class CurrencyOfferingPurchaseTransfer
    {
        public Guid PurchaseId { get; set; }
        public CurrencyOfferingPurchase Purchase { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateToTransfer { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public bool IsTransfered { get; set; }

        /// <summary>Amount that will be transfered that day</summary>
        public decimal Amount { get; set; }

        public string GetUniqueId() => $"{PurchaseId}_{DateToTransfer:yyy-MM-dd}";

        public override string ToString() => $"{nameof(CurrencyOfferingPurchaseTransfer)}" +
            $"({GetUniqueId()}, Amount:{Amount}, transfered:{IsTransfered})";
    }
}
