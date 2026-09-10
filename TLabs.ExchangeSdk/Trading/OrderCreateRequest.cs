using System;

namespace TLabs.ExchangeSdk.Trading
{
    public class OrderCreateRequest
    {
        /// <summary>Becomes order Id in matching-engine</summary>
        public string ActionId { get; set; }

        public bool IsMarket { get; set; }
        public bool IsBid { get; set; }
        public string CurrencyPairCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }

        /// <summary>Цена триггера условного ордера; null — обычный ордер. С IsMarket — только на продажу</summary>
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// Сторона триггера, заполняется брокером (значение клиента перезаписывается);
        /// null — старый брокер, сторона выводится из IsBid как у классического стопа
        /// </summary>
        public bool? StopTriggerAbove { get; set; }

        /// <summary>OCO: цена тейк-профита к StopPrice (стоп-лоссу); только стоп-маркет на продажу</summary>
        public decimal? TakeProfitPrice { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ClientType ClientType { get; set; }
        public string UserId { get; set; }

        /// <summary>Local, unless order is from LiquidtyImport</summary>
        public Exchange Exchange { get; set; } = Exchange.Local;

        /// <summary>Amount that was blocked in Depository for a market bid</summary>
        public decimal MarketBidTotalBlocked { get; set; }

        public Order GetOrder()
        {
            return new Order
            {
                Id = Guid.Parse(ActionId),
                IsMarket = IsMarket,
                IsBid = IsBid,
                Price = Price,
                StopPrice = StopPrice,
                StopTriggerAbove = StopTriggerAbove ?? IsBid,
                TakeProfitPrice = TakeProfitPrice,
                Amount = Amount,
                CurrencyPairCode = CurrencyPairCode,
                DateCreated = DateCreated,
                UserId = UserId,
                ClientType = ClientType,
                Exchange = Exchange,
                MarketBidTotalBlocked = MarketBidTotalBlocked,
            };
        }

        public override string ToString() => $"{nameof(OrderCreateRequest)}({(IsMarket ? "Market" : "")}{(IsBid ? "Bid" : "Ask")} " +
            $"{CurrencyPairCode}, Amount:{Amount}, Price:{Price}, {ClientType} {UserId}, ActionId: {ActionId})";
    }
}
