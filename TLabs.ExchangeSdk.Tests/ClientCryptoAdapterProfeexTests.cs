using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Features.Profeex;

namespace TLabs.ExchangeSdk.Tests
{
    [TestFixture]
    public class ClientCryptoAdapterProfeexTests
    {
        private HttpTest _httpTest;
        private ClientCryptoAdapterProfeex _client;

        [SetUp]
        public void Setup()
        {
            FlurlExtensions.InitFlurl(Constants.GatewayUrl);
            _httpTest = new HttpTest();
            _client = new ClientCryptoAdapterProfeex();
        }

        [TearDown]
        public void TearDown() => _httpTest.Dispose();

        [Test]
        public async Task GetUserInfo_calls_users_info_route_and_parses_payload()
        {
            _httpTest.RespondWithJson(new
            {
                UserId = 12345,
                Balances = new { TRX = "1500.25", USDT = "320.00" },
                DepositAddress = "TLsV52sRDL79HXGGm9yzwKibb6BeruhUzy",
                RegistrationDate = "2024-06-15T10:30:00Z",
            });

            var result = await _client.GetUserInfo();

            _httpTest.ShouldHaveCalled("*/profeex/users/info").WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(12345, result.Data.UserId);
            Assert.AreEqual("1500.25", result.Data.Balances["TRX"]);
            Assert.AreEqual("TLsV52sRDL79HXGGm9yzwKibb6BeruhUzy", result.Data.DepositAddress);
        }

        [Test]
        public async Task GetBalance_returns_failed_query_result_on_503()
        {
            _httpTest.RespondWith(status: 503, body: "Account Service unavailable");

            var result = await _client.GetBalance();

            Assert.IsFalse(result.Succeeded);
        }

        [Test]
        public async Task PrecountEnergy_uses_GET_with_correct_query_params()
        {
            _httpTest.RespondWithJson(new
            {
                Duration = "3d", Volume = 65000, Price = 0.0023m, Summa = 150.75m, Currency = "TRX",
            });

            var pricing = await _client.PrecountEnergy(new ProfeexPrecountRequest
            {
                Volume = 65000, Days = ProfeexDuration.Day3, Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/precount/energy*")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("volume", 65000)
                .WithQueryParam("days", "3d")
                .WithQueryParam("currency", "TRX");
            Assert.IsTrue(pricing.Succeeded);
            Assert.AreEqual(150.75m, pricing.Data.Summa);
            Assert.AreEqual(ProfeexCurrency.TRX, pricing.Data.Currency);
        }

        [Test]
        public async Task PrecountBandwidth_targets_bandwidth_route()
        {
            _httpTest.RespondWithJson(new { Duration = "1d", Volume = 100, Price = 0.0001m, Summa = 0.01m, Currency = "USDT" });

            await _client.PrecountBandwidth(new ProfeexPrecountRequest
            {
                Volume = 100, Days = ProfeexDuration.Day1, Currency = ProfeexCurrency.USDT,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/precount/bandwidth*")
                .WithQueryParam("currency", "USDT");
        }

        [Test]
        public async Task PrecountBatchEnergy_targets_batchenergy_route()
        {
            _httpTest.RespondWithJson(new { Duration = "7d", Volume = 65000, Price = 0.0025m, Summa = 162.50m, Currency = "TRX" });

            await _client.PrecountBatchEnergy(new ProfeexPrecountRequest
            {
                Volume = 65000, Days = ProfeexDuration.Day7, Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/precount/batchenergy*");
        }

        [Test]
        public async Task BuyEnergy_posts_with_query_params_and_returns_task_id()
        {
            const string taskId = "550e8400-e29b-41d4-a716-446655440000";
            _httpTest.RespondWithJson(new
            {
                Message = "Task accepted and queued",
                TaskId = taskId,
                Status = "ACTIVE",
                Target = "TLsV52sRDL79HXGGm9yzwKibb6BeruhUzy",
                Volume = 65000,
                Days = "3d",
                Currency = "TRX",
                ResourceType = "ENERGY",
                Balances = new { TRX = "1349.25", USDT = "320.00" },
            }, status: 202);

            var result = await _client.BuyEnergy(new ProfeexBuyResourceRequest
            {
                Target = "TLsV52sRDL79HXGGm9yzwKibb6BeruhUzy",
                Volume = 65000, Days = ProfeexDuration.Day3, Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/buyenergy*")
                .WithVerb(HttpMethod.Post)
                .WithQueryParam("target", "TLsV52sRDL79HXGGm9yzwKibb6BeruhUzy")
                .WithQueryParam("volume", 65000)
                .WithQueryParam("days", "3d")
                .WithQueryParam("currency", "TRX");
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(taskId, result.Data.TaskId);
            Assert.AreEqual(ProfeexOrderStatus.Active, result.Data.Status);
            Assert.AreEqual(ProfeexResourceType.Energy, result.Data.ResourceType);
        }

        [Test]
        public async Task BuyBandwidth_targets_buybandwidth_route()
        {
            _httpTest.RespondWithJson(new
            {
                Message = "Task accepted and queued", TaskId = Guid.NewGuid().ToString(), Status = "QUEUED",
                Target = "T1", Volume = 1, Days = "1d", Currency = "TRX", ResourceType = "BANDWIDTH",
            }, status: 202);

            await _client.BuyBandwidth(new ProfeexBuyResourceRequest
            {
                Target = "T1", Volume = 1, Days = ProfeexDuration.Day1, Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/buybandwidth*").WithVerb(HttpMethod.Post);
        }

        [Test]
        public async Task BuyBatchEnergy_targets_batchenergy_route()
        {
            _httpTest.RespondWithJson(new
            {
                Message = "ok", TaskId = Guid.NewGuid().ToString(), Status = "QUEUED",
                Target = "T1", Volume = 1, Days = "1d", Currency = "TRX", ResourceType = "ENERGY",
            }, status: 202);

            await _client.BuyBatchEnergy(new ProfeexBuyResourceRequest
            {
                Target = "T1", Volume = 1, Days = ProfeexDuration.Day1, Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/delegation/batchenergy*").WithVerb(HttpMethod.Post);
        }

        [Test]
        public async Task GetOrderStatus_parses_active_status()
        {
            _httpTest.RespondWithJson(new
            {
                TaskId = "abc",
                Status = "ACTIVE",
                Details = new { TargetAddress = "T1", Volume = 65000, Txid = "tx123" },
                ErrorCode = (string)null,
            });

            var result = await _client.GetOrderStatus("abc");

            _httpTest.ShouldHaveCalled("*/profeex/delegation/status/abc").WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(ProfeexOrderStatus.Active, result.Data.Status);
            Assert.IsNull(result.Data.ErrorCode);
        }

        [Test]
        public async Task GetOrderStatus_parses_failed_status_with_error_code()
        {
            _httpTest.RespondWithJson(new
            {
                TaskId = "abc",
                Status = "FAILED",
                Details = new { ErrorMessage = "Recently delegated" },
                ErrorCode = "DUPLICATE_REQUEST",
            });

            var result = await _client.GetOrderStatus("abc");

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(ProfeexOrderStatus.Failed, result.Data.Status);
            Assert.AreEqual(ProfeexErrorCode.DuplicateRequest, result.Data.ErrorCode);
        }

        [Test]
        public async Task CalculateUsdtTransferFee_sends_receiver_address_query()
        {
            _httpTest.RespondWithJson(new
            {
                ReceiverAddress = "TQ", EnergyRequired = 31664, TrxBurned = 6.649m, IsNewAddress = false,
            });

            var result = await _client.CalculateUsdtTransferFee("TQ");

            _httpTest.ShouldHaveCalled("*/profeex/delegation/fee*")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("receiver_address", "TQ");
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(31664, result.Data.EnergyRequired);
            Assert.AreEqual(6.649m, result.Data.TrxBurned);
            Assert.IsFalse(result.Data.IsNewAddress);
        }

        [Test]
        public async Task RequestActivation_posts_with_address_and_currency_query()
        {
            _httpTest.RespondWithJson(new
            {
                Message = "Activation task accepted and queued",
                TaskId = "act-1",
                Status = "QUEUED",
                Target = "TN",
                Balances = new { TRX = "1498.50", USDT = "320.00" },
            }, status: 202);

            var result = await _client.RequestActivation(new ProfeexActivationRequest
            {
                Address = "TN", Currency = ProfeexCurrency.TRX,
            });

            _httpTest.ShouldHaveCalled("*/profeex/activation/activate*")
                .WithVerb(HttpMethod.Post)
                .WithQueryParam("address", "TN")
                .WithQueryParam("currency", "TRX");
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual("act-1", result.Data.TaskId);
            Assert.AreEqual(ProfeexOrderStatus.Queued, result.Data.Status);
        }

        [Test]
        public async Task GetActivationCost_returns_cost_in_trx()
        {
            _httpTest.RespondWithJson(new { CostTrx = 1.5m, Description = "Activation", Currency = "TRX" });

            var result = await _client.GetActivationCost();

            _httpTest.ShouldHaveCalled("*/profeex/activation/cost").WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(1.5m, result.Data.CostTrx);
            Assert.AreEqual(ProfeexCurrency.TRX, result.Data.Currency);
        }

        [Test]
        public async Task GetOrderHistory_passes_pagination_filters_and_sort()
        {
            _httpTest.RespondWithJson(new
            {
                Items = new object[0],
                Total = 0, Page = 2, Size = 25, Pages = 0, HasNext = false, HasPrevious = true,
            });

            await _client.GetOrderHistory(new ProfeexOrderHistoryQuery
            {
                Page = 2,
                Size = 25,
                Last = "7d",
                Status = ProfeexOrderStatus.Completed,
                ResourceType = ProfeexResourceType.Energy,
                Sort = "-summa",
            });

            _httpTest.ShouldHaveCalled("*/profeex/orders/history*")
                .WithVerb(HttpMethod.Get)
                .WithQueryParam("page", 2)
                .WithQueryParam("size", 25)
                .WithQueryParam("last", "7d")
                .WithQueryParam("status", "COMPLETED")
                .WithQueryParam("resource_type", "ENERGY")
                .WithQueryParam("sort", "-summa");
        }

        [Test]
        public async Task GetOrderHistory_does_not_send_date_filters_when_not_set()
        {
            _httpTest.RespondWithJson(new
            {
                Items = new object[0],
                Total = 0, Page = 1, Size = 10, Pages = 0, HasNext = false, HasPrevious = false,
            });

            await _client.GetOrderHistory(new ProfeexOrderHistoryQuery());

            _httpTest.ShouldHaveCalled("*/profeex/orders/history*")
                .WithoutQueryParam("date_from")
                .WithoutQueryParam("date_to")
                .WithoutQueryParam("last")
                .WithoutQueryParam("status")
                .WithoutQueryParam("resource_type");
        }

        [Test]
        public void ProfeexEnumConverter_round_trips_screaming_snake_case()
        {
            Assert.AreEqual("DUPLICATE_REQUEST", ProfeexEnumConverter.ToScreamingSnake("DuplicateRequest"));
            Assert.AreEqual("ACTIVE", ProfeexEnumConverter.ToScreamingSnake("Active"));
            Assert.AreEqual("DuplicateRequest", ProfeexEnumConverter.FromScreamingSnake("DUPLICATE_REQUEST"));
            Assert.AreEqual("Active", ProfeexEnumConverter.FromScreamingSnake("ACTIVE"));
        }
    }
}
