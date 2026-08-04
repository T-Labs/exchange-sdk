# PROJECT KNOWLEDGE BASE

**Generated:** 2026-07-25
**Commit:** 524412d
**Branch:** master

## OVERVIEW

Shared .NET 7 SDK packaged as `TLabs.ExchangeSdk`. It exposes typed gateway clients, DTOs, caches, and integration helpers consumed by the trading services.

## STRUCTURE

```text
TLabs.ExchangeSdk/          # Library; domain folders contain Client*, DTOs, enums, models
TLabs.ExchangeSdk.Tests/    # NUnit unit and local-gateway integration tests
TLabs.ExchangeSdk.sln
```

Major domains include `Trading`, `Depository`, `Brokerage`, `LiquidityImport`, `PaymentCards`, `P2P`, `Staking`, `Notificator`, `Aml`, `Users`, and `Withdrawals`.

## WHERE TO LOOK

| Task | Location | Notes |
| --- | --- | --- |
| Register a client | `TLabs.ExchangeSdk/ServiceCollectionExtensions.cs` | `AddSdkServices`; clients transient, caches singleton |
| Add/change a gateway API | Neighboring domain `Client*.cs` | Preserve endpoint paths and DTO wire names |
| Trading calls | `TLabs.ExchangeSdk/Trading/` | Market data and order helpers |
| Transaction/balance calls | `TLabs.ExchangeSdk/Depository/ClientDepository.cs` | Calls `TxCommandDto.Clean()` before send |
| Notification delivery | `TLabs.ExchangeSdk/Notificator/ClientNotificator.cs` | HTTP 202/Pending is valid asynchronous behavior |
| Tests | `TLabs.ExchangeSdk.Tests/` | NUnit; some tests require a local gateway |

## CODE MAP

| Symbol | Type | Location | Role |
| --- | --- | --- | --- |
| `ServiceCollectionExtensions.AddSdkServices` | method | `TLabs.ExchangeSdk/ServiceCollectionExtensions.cs` | Central DI composition |
| `ClientMarketdata` | client | `TLabs.ExchangeSdk/Trading/ClientMarketdata.cs` | Representative Flurl API pattern |
| `ClientDepository` | client | `TLabs.ExchangeSdk/Depository/ClientDepository.cs` | Transactions and balances |
| `ClientPaymentCards` | client | `TLabs.ExchangeSdk/PaymentCards/ClientPaymentCards.cs` | Idempotency and sensitive endpoints |

## CONVENTIONS

- Target `net7.0`; do not upgrade framework or core packages incidentally.
- Reuse `TLabs.DotnetHelpers` Flurl `InternalApi()` and typed JSON helpers.
- Public network methods are asynchronous `Task`/`Task<T>`.
- Serialize dates using round-trip `"o"` where existing clients do so; preserve nullable query behavior.
- Keep DTOs, enums, and models beside their domain client.
- Register every new client in `AddSdkServices()` using the neighboring lifetime pattern.
- Expensive market-data and transaction operations may intentionally use long timeouts.

## ANTI-PATTERNS

- Do not rename routes or serialized properties without checking every consuming service.
- Do not assume Notificator accepted work was delivered synchronously.
- Do not consolidate addresses for AML-unconfirmed deposit transaction IDs.
- Never commit credentials or real gateway URLs.
- Do not edit `bin/` or `obj/`.

## COMMANDS

```bash
dotnet restore TLabs.ExchangeSdk.sln
dotnet build TLabs.ExchangeSdk.sln
dotnet test TLabs.ExchangeSdk.Tests/TLabs.ExchangeSdk.Tests.csproj
```

`ApiCallTests` expects a gateway at `http://localhost:5331/api/`; separate it from pure unit verification when the gateway is unavailable.
