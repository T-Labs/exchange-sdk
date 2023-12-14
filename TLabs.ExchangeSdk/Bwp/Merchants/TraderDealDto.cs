using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp.Merchants;

public class TraderDealDto
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal CryptoAmount { get; set; }
    public decimal FiatAmount { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset Finished { get; set; }
    public DealDtoStatus Status { get; set; }
}
public enum DealDtoStatus
{
    InProcess = 10,
    Successful = 20,
    Disputed = 30,
    ClosedByExpired = 40,
    AdminClosed = 50,
}
