using System;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexOrderHistoryDto
{
    public string TaskId { get; set; }

    public long UserId { get; set; }

    public string TargetAddress { get; set; }

    public ProfeexResourceType ResourceType { get; set; }

    public ProfeexCurrency Currency { get; set; }

    public string Duration { get; set; }

    public long Volume { get; set; }

    public decimal Summa { get; set; }

    public ProfeexOrderStatus Status { get; set; }

    public string Txid { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}
