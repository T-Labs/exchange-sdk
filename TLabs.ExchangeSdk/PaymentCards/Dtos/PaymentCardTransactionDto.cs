using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardTransactionDto
{
    public long Id { get; set; }
    public Guid CardId { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string BillingCurrency { get; set; }
    public decimal? BillingAmount { get; set; }
    public decimal? BillingTransactionFee { get; set; }
    public string TransactionCurrency { get; set; }
    public string TransactionAmount { get; set; }
    public string MerchantName { get; set; }
    public string Description { get; set; }
    public decimal? CardBalanceBefore { get; set; }
    public decimal? CardBalanceAfter { get; set; }
    public DateTimeOffset? OccurTime { get; set; }
    public string FailureReason { get; set; }
}

public class PaymentCardTransactionsResultDto
{
    public List<PaymentCardTransactionDto> Items { get; set; } = new();
    public int TotalCount { get; set; }
}
