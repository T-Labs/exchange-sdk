using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Staking;

public class BiniTransferRecipientsReportDto
{
    public string SenderUserId { get; set; }
    public string SenderEmail { get; set; }
    public List<BiniTransferRecipientRowDto> Recipients { get; set; } = new();
}

public class BiniTransferRecipientRowDto
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public decimal ReceivedAmount { get; set; }
    public DateTimeOffset? FirstReceivedAt { get; set; }

    public bool NoYearlyStaking { get; set; }
    public decimal ActiveAnnualStakedAmount { get; set; }
    public decimal AnnualStakeShortfall { get; set; }

    public SoldChannelDto SpotSell { get; set; } = new();
    public SoldChannelDto ExternalWithdrawal { get; set; } = new();
    public SoldChannelDto OnwardInternalTransfer { get; set; } = new();
    public SoldBalanceDto BalanceHeuristic { get; set; } = new();
}

public class SoldCounterpartyDto
{
    public string IdOrAddress { get; set; }
    public string Label { get; set; }
    public decimal Amount { get; set; }
}

public class SoldChannelDto
{
    public bool Flag { get; set; }
    public decimal Amount { get; set; }
    public List<SoldCounterpartyDto> Counterparties { get; set; } = new();
}

public class SoldBalanceDto
{
    public bool Flag { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal Shortfall { get; set; }
}
