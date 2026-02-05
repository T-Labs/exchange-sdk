# Code Quality Assessment — TLabs.ExchangeSdk

**Date:** 2026-02-05
**Scope:** 203 C# source files across 28 modules, 3 test files
**Framework:** .NET 7.0 SDK library

---

## 1. BUG — Inverted null check in `IPService.GetHeaderValueAs<T>`

**File:** `TLabs.ExchangeSdk/Users/IPService.cs:67-69`

```csharp
if (headers == null)  // BUG: should be != null
{
    if (headers.TryGetValue(headerName, out StringValues values))  // NullReferenceException
```

The condition is `== null` but the body dereferences `headers`. This means:
- When headers **exist**, the method skips them and always returns `default`
- When headers are **null**, it crashes with `NullReferenceException`

The entire X-Forwarded-For header lookup is broken. `GetRequestIP()` falls through to `RemoteIpAddress` every time.

---

## 2. BUG — Cyrillic "С" (U+0421) in filename

**File:** `TLabs.ExchangeSdk/Commissions/Сommission.cs`

The first character is **Cyrillic С (U+0421)**, not **Latin C (U+0043)**. This will cause:
- Search/grep for "Commission" will miss this file
- IDE refactoring tools may fail to locate the file
- Potential build issues on case-sensitive file systems

---

## 3. Resource leak — `RabbitMqSender.Send()`

**File:** `TLabs.ExchangeSdk/RabbitMq/RabbitMqSender.cs:40-44`

```csharp
IConnection conn = factory.CreateConnection();
IModel channel = conn.CreateModel();
channel.QueueDeclare(queue, true, false, false, null);
channel.BasicPublish("", queue, null, Encoding.UTF8.GetBytes(json));
conn.Close();  // channel never closed/disposed; conn not disposed on exception
```

Both `IConnection` and `IModel` implement `IDisposable`. If an exception occurs between
`CreateConnection()` and `Close()`, the connection leaks. The channel is never disposed at all.
Should use `using` statements.

---

## 4. Resource leak — `CancellationTokenSource` never disposed

**File:** `TLabs.ExchangeSdk/CryptoAdapters/ClientCryptoAdapters.cs:54, 87, 101`

```csharp
var cancelToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
```

`CancellationTokenSource` implements `IDisposable` and internally allocates a `Timer`.
Created in three methods and never disposed.

---

## 5. HTTP attributes on SDK client class (wrong layer)

**File:** `TLabs.ExchangeSdk/News/ClientNews.cs:206, 214, 222`

```csharp
[HttpPut("{id}")]
public async Task<IFlurlResponse> UpdateSignalChannel(...)
[HttpPost]
public async Task<IFlurlResponse> CreateSignalChannel(...)
[HttpDelete("{id}")]
public async Task<IFlurlResponse> DeleteSignalChannel(...)
```

`[HttpPut]`, `[HttpPost]`, `[HttpDelete]` are ASP.NET controller routing attributes. They have
no effect on an SDK client class and appear to be copy-paste artifacts from a controller.

---

## 6. `Console.WriteLine` in production code

**File:** `TLabs.ExchangeSdk/CryptoAdapters/ClientCryptoAdapters.cs:119, 127`

```csharp
Console.WriteLine($"ResendTransaction txHash change: {txHash} -> {result.Data}  {result.ErrorsString}");
Console.WriteLine($"CancelTransaction txHash change: {txHash} -> {result.Data}  {result.ErrorsString}");
```

The class has no `ILogger` injected (unlike sibling classes), and uses `Console.WriteLine` for
logging transaction hash changes. This bypasses structured logging, log levels, and log aggregation.

---

## 7. Sensitive data logged in full

**File:** `TLabs.ExchangeSdk/RabbitMq/RabbitMqSender.cs:35, 45, 50`

```csharp
string requestInfo = $"queue:{queue}, json:{json}, url:{urlRabbitMq}";
_logger.LogInformation($"RabbitMq sent to {requestInfo}");
_logger.LogError(e, requestInfo);
```

The full message JSON body (which may contain user PII, card numbers, financial data) and
the RabbitMQ connection URL (which may contain credentials) are logged on every send and every error.

---

## 8. Mutable static fields (thread safety)

Multiple classes expose `public static` mutable lists without `readonly`:

| File | Line | Field |
|------|------|-------|
| `Currencies/Adapter.cs` | 21-38 | 13 `public static Adapter` fields + `DefaultAdapters` list — none `readonly` |
| `Commissions/CommissionType.cs` | 42 | `TypesUsingCurrencyPair` — not `readonly` |
| `Users/UserRoles.cs` | 32 | `AllRoles` — not `readonly` |

Any consumer can reassign these fields or mutate the lists. In a multi-threaded server,
this is a race condition.

---

## 9. Inconsistent naming conventions

### Constants — three different styles

| File | Style | Example |
|------|-------|---------|
| `Withdrawals/ClientWithdrawals.cs:12` | camelCase | `private const string baseUrl` |
| `CashExchanges/ClientCashExchanges.cs:12` | UPPER_SNAKE | `private const string BASE_EXCHANGE_URL` |
| `News/ClientNews.cs:15` | PascalCase | `private const string BaseUrl` |

### Method naming — Async suffix

`CashHandover/ClientCashHandovers.cs` uses `Async` suffix on all methods (`CreateRequestAsync`,
`GetDealNumberAsync`, etc.). Every other client class in the codebase omits the suffix.

### Client class naming — reversed pattern

| File | Naming | Convention |
|------|--------|-----------|
| `Depository/ClientDepository.cs` | `Client{Feature}` | Standard |
| `CashHandover/CashHandoverClient.cs` | `{Feature}Client` | Reversed |

---

## 10. Missing `async`/`await` — changed exception behavior

**File:** `TLabs.ExchangeSdk/News/ClientNews.cs:17-23`

```csharp
public Task<JsonResult> Healthcheck()
{
    var result = $"news/healthcheck".InternalApi().GetJsonAsync<JsonResult>();
    return result;
}
```

Returns `Task` without `async`/`await`. If `GetJsonAsync` throws synchronously (e.g., URI
construction failure), the exception propagates synchronously instead of being captured in the Task.

---

## 11. Obsolete code included in active collections

**File:** `TLabs.ExchangeSdk/Depository/TransactionType.cs:54-55, 189`

```csharp
[Obsolete] public static readonly TransactionType WithdrawalBlockRollback = ...
[Obsolete] public static readonly TransactionType WithdrawalStockCommissionBlockRollback = ...
```

Both are marked `[Obsolete]` but still included in the `All` list (line 189). Consumers
iterating `TransactionType.All` will process obsolete types.

---

## 12. `TransactionType.All` missing `DepositCash`

**File:** `TLabs.ExchangeSdk/Depository/TransactionType.cs`

`DepositCash` (code "105", line 32) is defined but absent from the `All` list (lines 174-239).
Any code using `TransactionType.All` to seed database rows, validate types, or iterate over
known types will miss cash deposits.

---

## 13. Unused internal import

**File:** `TLabs.ExchangeSdk/Depository/TxCommandDto.cs:1`

```csharp
using RabbitMQ.Client.Impl;
```

This is an **internal** namespace of the RabbitMQ client library. Unused in the file and creates
a dependency on implementation details that could break on RabbitMQ package updates.

---

## 14. Test coverage is near zero

| Metric | Value |
|--------|-------|
| SDK source files | 203 |
| Test files | 3 |
| Test methods | ~8 |
| Code:test ratio | ~84:1 |

Only `OrderHelper.GetOrderByDirection()` has tests. No coverage for client classes, DTOs,
RabbitMQ, error handling, or domain logic. Test dependencies are severely outdated
(NUnit 3.12 from ~2019, Moq 4.15 from ~2021).

---

## 15. God classes

| Class | Lines | Methods | Concern mix |
|-------|-------|---------|------------|
| `P2P/ClientP2P.cs` | 413 | 20+ | Orders, deals, requisites, chat, disputes |
| `Users/ClientUsers.cs` | 363 | 29 | User CRUD, roles, claims, 2FA, KYC, settings |
| `News/ClientNews.cs` | 272 | 18+ | News, comments, likes, signals, FAQ, images |
| `Farming/ClientFarming.cs` | 267 | 27 | Tasks, farming, rewards, referrals |

---

## 16. DTO validation almost nonexistent

Out of ~51 DTO files, very few use validation attributes beyond occasional `[Required]`.
No `[StringLength]`, `[Range]`, or `[RegularExpression]` constraints on fields like card numbers,
amounts, user IDs, or email addresses.

---

## Summary by severity

| Severity | # | Issues |
|----------|---|--------|
| **Bug** | 2 | #1 Inverted null check (NRE), #12 Missing DepositCash in All list |
| **High** | 4 | #2 Cyrillic filename, #3 RabbitMQ resource leak, #4 CTS leak, #7 Sensitive data logged |
| **Medium** | 5 | #5 HTTP attrs on client, #6 Console.WriteLine, #8 Mutable statics, #10 Missing async, #11 Obsolete in active list |
| **Low** | 5 | #9 Naming inconsistency, #13 Unused import, #14 Test coverage, #15 God classes, #16 Missing validation |
