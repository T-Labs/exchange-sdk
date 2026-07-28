using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Depository.Futures;

namespace TLabs.ExchangeSdk.Tests
{
    public class FuturesLedgerContractTests
    {
        [Test]
        public async Task FuturesLedgerClient_SendsExpectedRoutes_WhenLedgerRequestsAreMade()
        {
            // Given
            FlurlExtensions.InitFlurl(Constants.GatewayUrl);
            using var httpTest = new HttpTest();
            var client = new ClientFuturesDepository();
            httpTest.RespondWithJson(new FuturesLedgerAccountSnapshot());
            httpTest.RespondWithJson(new FuturesLedgerAccountSnapshot());
            httpTest.RespondWithJson(new FuturesLedgerOperationResult());

            // When
            await client.EnsureAccount(new FuturesLedgerEnsureAccountRequest
            {
                FuturesAccountId = 42,
                UserId = "user-42",
                CurrencyCode = "USDT"
            });
            await client.GetAccount(42, "user-42", "USDT");
            await client.ExecuteOperation(new FuturesLedgerOperationRequest
            {
                ActionId = "action-42",
                OperationType = FuturesLedgerOperationType.TransferFromSpot,
                FuturesAccountId = 42,
                UserId = "user-42",
                CurrencyCode = "USDT",
                Amount = 12.34m
            });

            // Then
            httpTest.ShouldHaveCalled($"{Constants.GatewayUrl}depository/futures-ledger/account")
                .WithVerb(HttpMethod.Post)
                .Times(1);
            httpTest.ShouldHaveCalled($"{Constants.GatewayUrl}depository/futures-ledger/account/42*")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("userId", "user-42")
                .WithQueryParam("currencyCode", "USDT")
                .Times(1);
            httpTest.ShouldHaveCalled($"{Constants.GatewayUrl}depository/futures-ledger/operation")
                .WithVerb(HttpMethod.Post)
                .Times(1);
        }

        [Test]
        public void AddSdkServices_RegistersFuturesLedgerClient()
        {
            // Given
            var services = new ServiceCollection();

            // When
            services.AddSdkServices();
            using var provider = services.BuildServiceProvider();

            // Then
            Assert.That(provider.GetService<ClientFuturesDepository>(), Is.Not.Null);
        }

        [Test]
        public void FuturesLedgerDtos_PreserveLedgerContractValues()
        {
            // Given
            var accountId = Guid.NewGuid();
            var blockedAccountId = Guid.NewGuid();

            // When
            var snapshot = new FuturesLedgerAccountSnapshot
            {
                FuturesAccountId = 42,
                UserId = "user-42",
                CurrencyCode = "USDT",
                BalanceAccountId = accountId,
                BlockedCopyTradingAccountId = blockedAccountId,
                Balance = 12.34m,
                BlockedCopyTradingBalance = 5.67m
            };
            var operation = new FuturesLedgerOperationRequest
            {
                ActionId = "action-42",
                OperationType = FuturesLedgerOperationType.TransferBetweenAccounts,
                FuturesAccountId = 42,
                UserId = "user-42",
                CurrencyCode = "USDT",
                Amount = 12.34m,
                CounterpartyFuturesAccountId = 99,
                CounterpartyUserId = "user-99"
            };
            var result = new FuturesLedgerOperationResult
            {
                PrimaryBalance = snapshot
            };

            // Then
            Assert.Multiple(() =>
            {
                Assert.That(snapshot.FuturesAccountId, Is.EqualTo(42));
                Assert.That(snapshot.BalanceAccountId, Is.EqualTo(accountId));
                Assert.That(snapshot.BlockedCopyTradingAccountId, Is.EqualTo(blockedAccountId));
                Assert.That(snapshot.Balance, Is.EqualTo(12.34m));
                Assert.That(snapshot.BlockedCopyTradingBalance, Is.EqualTo(5.67m));
                Assert.That(operation.CounterpartyFuturesAccountId, Is.EqualTo(99));
                Assert.That(operation.CounterpartyUserId, Is.EqualTo("user-99"));
                Assert.That(result.PrimaryBalance, Is.SameAs(snapshot));
                Assert.That(result.CounterpartyBalance, Is.Null);
                Assert.That(FuturesLedgerOperationType.ResetBalance, Is.EqualTo((FuturesLedgerOperationType)9));
            });
        }

    }
}
