#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public sealed record FuturesTransferStatusDto(
    Guid TransferId,
    string Direction,
    long FuturesAccountId,
    string Currency,
    string Amount,
    string State,
    string? FailureReason,
    DateTime CreatedAt,
    DateTime UpdatedAt);

/// <summary>
///     Тело отказа по переводу. Код стабилен и предназначен для ветвления на клиенте.
///     400: invalid_idempotency_key, invalid_transfer_request, insufficient_spot_balance,
///     insufficient_futures_balance, transfer_low_margin, transfer_amount_limit_exceeded.
///     403: transfers_disabled, trading_kyc_not_allowed.
///     404: account_not_found. 409: idempotency_conflict.
/// </summary>
public sealed record FuturesTransferErrorDto(string Code);
