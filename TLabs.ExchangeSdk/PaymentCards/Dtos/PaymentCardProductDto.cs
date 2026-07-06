using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardProductDto
{
    public Guid Id { get; set; }
    public int ExternalTemplateId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string PaymentSystem { get; set; }
    public string CurrencyCode { get; set; }

    public decimal? ApplyFee { get; set; }
    public decimal? RechargeFee { get; set; }
    public decimal? RefundFee { get; set; }
    public decimal? ActivateMinLimit { get; set; }
    public decimal? RechargeMinLimit { get; set; }
    public decimal? RechargeMaxLimit { get; set; }
    public decimal? LimitPerTx { get; set; }
    public decimal? LimitPerDay { get; set; }
    public decimal? LimitPerMonth { get; set; }

    public bool? RequiresKyc { get; set; }
    public bool? RequiresPhoneOnly { get; set; }
    public bool? NeedsActivation { get; set; }
    public bool? RequiresInitialDeposit { get; set; }
    public string AllowedPinLengths { get; set; }

    public bool Enabled { get; set; }
    public DateTimeOffset DateSynced { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardProductDto)}({ExternalTemplateId}, {Title}, Enabled:{Enabled})";
}
