using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk
{
    public class OrderLimit
    {
        [Key]
        public Guid UID { get; set; }

        #region CurencyTo

        [Required]
        public string CurrencyCodeTo { get; set; }

        #endregion
        #region CurencyFrom

        [Required]
        public string CurrencyCodeFrom { get; set; }

        #endregion

        [Required]
        public decimal QuoteAmount { get; set; }

        [Required]
        public decimal BaseAmount { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsLimited() => QuoteAmount != 0.0m || BaseAmount != 0.0m;

        public string CurrencyPairCode() => $"{CurrencyCodeTo}_{CurrencyCodeFrom}";

        public OrderLimit() => this.CreateTime = DateTime.UtcNow;
    }
}
