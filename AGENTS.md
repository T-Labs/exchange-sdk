# AGENTS.md — exchange-sdk

## Идентичность пакета

Общая библиотека **.NET 7** `TLabs.ExchangeSdk`: HTTP-клиенты (`Client*`), DTO, enums, константы depository. Потребляется микросервисами через **NuGet** или **ProjectReference** (локально).

## Setup и запуск

```powershell
cd exchange-sdk
dotnet build TLabs.ExchangeSdk.sln
dotnet test TLabs.ExchangeSdk.Tests/TLabs.ExchangeSdk.Tests.csproj
dotnet pack TLabs.ExchangeSdk/TLabs.ExchangeSdk.csproj -c Release
```

## Паттерны и конвенции

### Layout по фиче

```
TLabs.ExchangeSdk/{Feature}/
  Client{Feature}.cs      # IClient{Feature} + реализация
  Dtos/                   # публичные API-контракты
  Enums/                  # status/direction enums (шаг 10)
  Models/                 # общие константы (headers и т.п.)
```

- ✅ **ДЕЛАЙ**: `private const string BaseUrl = "brokerage/feature-kebab";` + `.InternalApi()` — см. `PaymentCards/ClientPaymentCards.cs`.
- ✅ **ДЕЛАЙ**: Interface + class в одном файле (`IClientPaymentCards` / `ClientPaymentCards`).
- ✅ **ДЕЛАЙ**: Регистрация в `ServiceCollectionExtensions.AddSdkServices()` как `Transient`.
- ✅ **ДЕЛАЙ**: `ToString()` на command DTO для логов.
- ✅ **ДЕЛАЙ**: Синхронизируй `TransactionType` / `AccountChart` depository со stock-depository.
- ❌ **НЕ ДЕЛАЙ**: EF-сущности или модели провайдера (Bananatech — только в brokerage).
- ❌ **НЕ ДЕЛАЙ**: Ломать binary compatibility без bump NuGet и обновления consumers.

### Payment Cards SDK (эталон)

| Артефакт | Путь |
|----------|------|
| Client (user) | `PaymentCards/ClientPaymentCards.cs` — без admin/sync/enable |
| Admin client | `PaymentCards/ClientPaymentCardsAdmin.cs` — cards/callbacks/block, products sync/enable |
| DTO | `PaymentCards/Dtos/*.cs` |
| Enums | `PaymentCards/Enums/*.cs` |

## Ключевые файлы

| Тема | Путь |
|------|------|
| DI | `TLabs.ExchangeSdk/ServiceCollectionExtensions.cs` |
| Flurl helper | `TLabs.ExchangeSdk/InternalApiExtensions.cs` |
| Depository types | `TLabs.ExchangeSdk/Depository/` |
| Тесты | `TLabs.ExchangeSdk.Tests/` |
| Доки | `../stock-docs/_docs/exchange-sdk.md` |

## JIT Index

```powershell
rg -n "class Client" TLabs.ExchangeSdk
rg -n "BaseUrl = " TLabs.ExchangeSdk
rg -n "AddTransient<IClient" TLabs.ExchangeSdk/ServiceCollectionExtensions.cs
dir TLabs.ExchangeSdk/PaymentCards
```

## Частые ошибки

- SDK **net7** vs сервисы **net10** — совместимы; не меняй TFM SDK без согласования.
- Brokerage/webapp — **ProjectReference**; depository/admin — старый **NuGet** — координируй publish (M13).
- После изменения SDK — rebuild всех consumers.

## Pre-PR

```powershell
cd exchange-sdk && dotnet build && dotnet test TLabs.ExchangeSdk.Tests/TLabs.ExchangeSdk.Tests.csproj
```
