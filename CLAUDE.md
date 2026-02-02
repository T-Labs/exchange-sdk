# TLabs.ExchangeSdk

Shared SDK library for a cryptocurrency exchange platform. Provides models, DTOs, enums, and HTTP/RabbitMQ clients for calling microservices.

## Tech Stack

- **C# / .NET 7.0** class library
- **RabbitMQ** (v5.1.0) for async messaging between services
- **Flurl.Http** for service-to-service HTTP calls
- **TLabs.DotnetHelpers** — internal helpers (`QueryResult<T>`, `.InternalApi()`, `.GetQueryResult()`, etc.)
- **NUnit + Moq** for tests

## Project Structure

```
TLabs.ExchangeSdk/          # Main library
  Affiliate/                 # Affiliate/referral program
  BinanceHandling/           # Binance integration
  Bwp/                       # Business wallet payments (merchants/traders)
  CashDeposits/              # Cash deposit handling
  CashExchanges/             # Cash exchange operations
  Commissions/               # Commission configuration and calculation
  CryptoAdapters/            # Blockchain adapters (Tron, Nownodes, etc.)
  Currencies/                # Currency, CurrencyPair, CurrencyListings, CurrencyOfferings
  Depository/                # Balances, transactions, accounts (85+ transaction types)
  Deposits/                  # Deposit processing
  Exchanges/                 # Exchange operations
  ExternalPayments/          # External payment processing
  Farming/                   # Token farming / airdrop / task rewards (multi-tenant)
  Files/                     # File management
  Helpdesk/                  # Support tickets
  LiquidityImport/           # Liquidity from external exchanges
  News/                      # News and announcements
  Ordering/                  # Order placement and matching
  P2P/                       # P2P trading (orders, deals, chat, disputes)
  RabbitMq/                  # Message queue sender and message types
  Staking/                   # On-chain locked staking
  Trading/                   # Core trading engine, market data, quotes
  TradingInnerBot/           # Internal trading bots
  Users/                     # User management (IdentityUser, 2FA, roles)
  Verification/              # KYC verification
  WebApp/                    # Web app integration
  Withdrawals/               # Withdrawal processing (crypto, bank card, internal)
TLabs.ExchangeSdk.Tests/     # NUnit tests
```

## Code Style

Configured in `.editorconfig`:
- **Indent:** 4 spaces
- **Line ending:** LF
- **Max line length:** 130 chars
- **Charset:** UTF-8
- **Trailing whitespace:** trimmed

### Naming Conventions

| Element         | Style              | Example                          |
|-----------------|--------------------|----------------------------------|
| Classes / Enums | PascalCase         | `Order`, `ClientType`            |
| Interfaces      | `I` + PascalCase   | `IIPService`                     |
| Properties      | PascalCase         | `CurrencyPairCode`, `IsBid`      |
| Private fields  | `_camelCase`       | `_logger`, `_config`             |
| Parameters      | camelCase          | `userId`, `currencyCode`         |
| Constants       | PascalCase / UPPER | `TransactionType.Deposit`        |

### Key Patterns

- **DTOs:** `{Feature}Dto`, `{Feature}CreateDto`, `{Feature}UpdateDto` — separate from domain models
- **Client classes:** `Client{Feature}` (e.g. `ClientDepository`, `ClientTradingBrokerage`) — one per microservice, registered as Transient via `services.AddSdkServices()`
- **Result type:** `QueryResult<T>` / `QueryResult` with `.Succeeded`, `.Data`, `.ErrorsString`
- **HTTP calls:** `"endpoint/path".InternalApi().PostJsonAsync(dto).GetQueryResult()`
- **RabbitMQ:** `RabbitMqSender.Send(queue, message)` — queues defined in `RabbitMqQueues`
- **Two-phase transactions:** `SendTwoStepTxCommands()` for atomic balance operations with rollback support
- **Static typed constants:** `TransactionType` uses `static readonly` instances, not enums
- **Caching:** `CurrenciesCache`, `TenantsCache` as singletons with reload endpoints
- **Async everywhere:** all I/O is `async Task<T>`

## Build & Package

- Package version managed in `TLabs.ExchangeSdk.csproj` (`1.0.x`)
- Published as NuGet package with `.snupkg` symbols
- Warning suppression: 1701, 1702, 1591

## Commands

```sh
dotnet build
dotnet test
```
