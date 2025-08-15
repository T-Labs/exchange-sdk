using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Depository
{
    public class TransactionType
    {
        /// <summary>
        /// Code
        /// </summary>
        [Key]
        public string Code { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Key for localization
        /// </summary>
        public string ValueKey { get; set; }

        public static readonly TransactionType Rollback = new TransactionType("001", "Откат", nameof(Rollback));

        public static readonly TransactionType Deposit = new TransactionType("101", "Пополнение баланса", nameof(Deposit));
        public static readonly TransactionType DepositAdmin = new TransactionType("102", "Безусловное пополнение баланса админом", nameof(DepositAdmin));
        public static readonly TransactionType DepositAirdrop = new TransactionType("103", "Безусловное пополнение баланса аирдропом", nameof(DepositAirdrop));
        public static readonly TransactionType DepositStaking = new TransactionType("104", "Безусловное пополнение баланса стейкингом", nameof(DepositStaking));
        public static readonly TransactionType DepositCash = new TransactionType("105", "Пополнение баланса кэшем", nameof(DepositCash));
        public static readonly TransactionType DepositToFunds = new TransactionType("106", "Пополнение баланса фондов", nameof(DepositToFunds));
        public static readonly TransactionType DepositReplacement = new TransactionType("108", "Пополнение баланса взамен удаленной валюты", nameof(DepositReplacement));
        public static readonly TransactionType DepositCorrection = new TransactionType("109", "Корректировочное пополнение баланса", nameof(DepositCorrection));

        public static readonly TransactionType Nullification = new TransactionType("121", "Обнуление баланса", nameof(Nullification));
        public static readonly TransactionType Confiscation = new TransactionType("125", "Конфискация баланса", nameof(Confiscation));

        public static readonly TransactionType WithdrawalBlockBegin = new TransactionType("06", "Блокировка для вывода начало", nameof(WithdrawalBlockBegin));
        public static readonly TransactionType WithdrawalBlockEnd = new TransactionType("0610", "Блокировка для вывода конец", nameof(WithdrawalBlockEnd));
        public static readonly TransactionType WithdrawalStockCommissionBlockBegin = new TransactionType("061", "Блокировка комиссии биржи для вывода начало", nameof(WithdrawalStockCommissionBlockBegin));
        public static readonly TransactionType WithdrawalStockCommissionBlockEnd = new TransactionType("0611", "Блокировка комиссии биржи для вывода конец", nameof(WithdrawalStockCommissionBlockEnd));
        public static readonly TransactionType WithdrawalBlockCancelBegin = new TransactionType("065", "Отмена блокировки для вывода начало", nameof(WithdrawalBlockCancelBegin));
        public static readonly TransactionType WithdrawalBlockCancelEnd = new TransactionType("0615", "Отмена блокировки для вывода конец", nameof(WithdrawalBlockCancelEnd));
        public static readonly TransactionType WithdrawalStockCommissionBlockCancelBegin = new TransactionType("066", "Отмена блокировки комиссии вывода начало", nameof(WithdrawalStockCommissionBlockCancelBegin));
        public static readonly TransactionType WithdrawalStockCommissionBlockCancelEnd = new TransactionType("0616", "Отмена блокировки комиссии вывода конец", nameof(WithdrawalStockCommissionBlockCancelEnd));
        public static readonly TransactionType WithdrawalBegin = new TransactionType("05", "Вывод средств начало", nameof(WithdrawalBegin));
        public static readonly TransactionType WithdrawalEnd = new TransactionType("0620", "Вывод средств конец", nameof(WithdrawalEnd));
        public static readonly TransactionType WithdrawalStockCommissionBegin = new TransactionType("062", "Комиссия вывода биржи начало", nameof(WithdrawalStockCommissionBegin));
        public static readonly TransactionType WithdrawalStockCommissionEnd = new TransactionType("0612", "Комиссия вывода биржи конец", nameof(WithdrawalStockCommissionEnd));

        public static readonly TransactionType WithdrawalNetworkCommission = new TransactionType("07", "Комиссия вывода блокчейна", nameof(WithdrawalNetworkCommission));
        [Obsolete] public static readonly TransactionType WithdrawalBlockRollback = new TransactionType("063", "Откат блокировки для вывода", nameof(WithdrawalBlockRollback));
        [Obsolete] public static readonly TransactionType WithdrawalStockCommissionBlockRollback = new TransactionType("064", "Откат блокировки комиссии биржи для вывода", nameof(WithdrawalStockCommissionBlockRollback));

        public static readonly TransactionType OrderingBegin = new TransactionType("201", "Начало выставления ордера", nameof(OrderingBegin));
        public static readonly TransactionType OrderingEnd = new TransactionType("211", "Подтверждение выставления ордера", nameof(OrderingEnd));
        public static readonly TransactionType OrderCancellingBegin = new TransactionType("202", "Начало отмены ордера", nameof(OrderCancellingBegin));
        public static readonly TransactionType OrderCancellingEnd = new TransactionType("221", "Подтверждение отмены ордера", nameof(OrderCancellingEnd));
        public static readonly TransactionType OrderExcessCancellingBegin = new TransactionType("223", "Начало отмены избытка бида", nameof(OrderExcessCancellingBegin));
        public static readonly TransactionType OrderExcessCancellingEnd = new TransactionType("224", "Подтверждение отмены избытка бида", nameof(OrderExcessCancellingEnd));
        public static readonly TransactionType Transfer = new TransactionType("03", "Перевод средств после сделки (old)", nameof(Transfer)); // Obsolete
        public static readonly TransactionType TransferBegin = new TransactionType("031", "Перевод средств после сделки начало", nameof(TransferBegin));
        public static readonly TransactionType TransferEnd = new TransactionType("032", "Перевод средств после сделки конец", nameof(TransferEnd));

        /// <summary>
        /// Move balance between Users and OnOrders accounts to fix previous trading errors
        /// </summary>
        public static readonly TransactionType OrderingReturnRemains = new TransactionType("209", "Возврат ошибочно неразблокированных средств", nameof(OrderingReturnRemains));

        public static readonly TransactionType Fee = new TransactionType("04", "Комиссия", nameof(Fee));

        public static readonly TransactionType NodeAgregationNetworkCommission = new TransactionType("071",
            "Комиссия блокчейна при агрегации средств ноды", nameof(NodeAgregationNetworkCommission));

        public static readonly TransactionType TransferToColdWallet = new TransactionType("11",
            "Перевод с кошелька ноды на холодный кошелек", nameof(TransferToColdWallet));

        public static readonly TransactionType BotDeposit = new TransactionType("301", "Пополнение счета Exchanger", nameof(BotDeposit));
        public static readonly TransactionType BotWithdrawal = new TransactionType("302", "Вывод со счета Exchanger", nameof(BotWithdrawal));
        public static readonly TransactionType BotCommission = new TransactionType("303", "Комиссия Exchanger", nameof(BotCommission));
        public static readonly TransactionType BotProfit = new TransactionType("304", "Прибыль Exchanger", nameof(BotProfit));
        public static readonly TransactionType BotTransferFromUser = new TransactionType("311", "Перевод юзера к боту", nameof(BotTransferFromUser));
        public static readonly TransactionType BotTransferToUser = new TransactionType("312", "Перевод бота к юзеру", nameof(BotTransferToUser));
        public static readonly TransactionType DealsBotTransferFromUser = new TransactionType("313", "Перевод юзера к боту для сделок", nameof(BotTransferFromUser));
        public static readonly TransactionType DealsBotTransferToUser = new TransactionType("314", "Перевод бота для сделок к юзеру", nameof(BotTransferToUser));

        public static readonly TransactionType InternalTransfer = new TransactionType("401", "Внутренний перевод", nameof(InternalTransfer));

        public static readonly TransactionType ExchangeTransfer = new TransactionType("431", "Перевод между юзерами при обмене", nameof(ExchangeTransfer)); // Obsolete
        public static readonly TransactionType ExchangeTransferBegin = new TransactionType("432", "Перевод между юзерами при обмене начало", nameof(ExchangeTransferBegin));
        public static readonly TransactionType ExchangeTransferEnd = new TransactionType("433", "Перевод между юзерами при обмене конец", nameof(ExchangeTransferEnd));
        public static readonly TransactionType ExchangeMarkup = new TransactionType("435", "Маркап обмена", nameof(ExchangeMarkup));
        public static readonly TransactionType ExchangeCommission = new TransactionType("436", "Комиссия обмена", nameof(ExchangeCommission));
        public static readonly TransactionType ExchangeCommissionConsolidation = new TransactionType("441", "Консолидация комиссии обмена", nameof(ExchangeCommissionConsolidation));

        public static readonly TransactionType AffiliateTariffPurchase = new TransactionType("801", "Покупка RefferalTariff", nameof(AffiliateTariffPurchase));
        public static readonly TransactionType AffiliateTariffPurchaseRollback = new TransactionType("802", "Откат покупки RefferalTariff", nameof(AffiliateTariffPurchaseRollback));
        public static readonly TransactionType AffiliateDealCommission = new TransactionType("803", "Refferal комиссия сделки", nameof(AffiliateDealCommission));
        public static readonly TransactionType AffiliateWithdrawalCommission = new TransactionType("805", "Refferal комиссия вывода", nameof(AffiliateWithdrawalCommission));
        public static readonly TransactionType AffiliateCurrencyListing = new TransactionType("806", "Refferal листинга валюты", nameof(AffiliateCurrencyListing));
        public static readonly TransactionType AffiliateApiTradeProfitPayment = new TransactionType("807", "Refferal оплаты за прибыль ApiTrade", nameof(AffiliateApiTradeProfitPayment));
        public static readonly TransactionType AffiliateClear = new TransactionType("809", "Affiliate очистка аккаунтов", nameof(AffiliateClear));
        public static readonly TransactionType AffiliateProfitPayment = new TransactionType("813", "Affiliate прибыль системе", nameof(AffiliateProfitPayment));
        public static readonly TransactionType AffiliateBonusesPayment = new TransactionType("815", "Affiliate бонусы юзеру", nameof(AffiliateBonusesPayment));

        public static readonly TransactionType BountyDistributionDeposit = new TransactionType("830", "Пополнение BuySell бонусов", nameof(BountyDistributionDeposit));
        public static readonly TransactionType BountyBonusesPayment = new TransactionType("831", "BuySell бонусы юзеру", nameof(BountyBonusesPayment));

        public static readonly TransactionType PaymentCardPurchase = new TransactionType("841", "Покупка Платежной Карты", nameof(PaymentCardPurchase));

        public static readonly TransactionType StakingFundProfit = new TransactionType("851", "Стейкинг прибыль системы из блокчейна", nameof(StakingFundProfit));
        public static readonly TransactionType StakingLock = new TransactionType("855", "Стейкинг заморозка средств", nameof(StakingLock));
        public static readonly TransactionType StakingUnlockBegin = new TransactionType("856", "Стейкинг начало разморозки средств", nameof(StakingUnlockBegin));
        public static readonly TransactionType StakingUnlockEnd = new TransactionType("857", "Стейкинг конец разморозки средств", nameof(StakingUnlockEnd));

        public static readonly TransactionType CurrencyListingDeployPayment = new TransactionType("873", "CurrencyListing оплата за деплой", nameof(CurrencyListingDeployPayment));
        public static readonly TransactionType CurrencyListingDealFeeProfit = new TransactionType("877", "CurrencyListing прибыль от торговой комиссии", nameof(CurrencyListingDealFeeProfit));

        public static readonly TransactionType ApiTradeProfitPayment = new TransactionType("891", "Оплата за прибыль ApiTrade", nameof(ApiTradeProfitPayment));

        public static readonly TransactionType CurrencyOfferingBuyBegin = new TransactionType("911", "Покупка CurrencyOffering начало", nameof(CurrencyOfferingBuyBegin));
        public static readonly TransactionType CurrencyOfferingBuyEnd = new TransactionType("912", "Покупка CurrencyOffering конец", nameof(CurrencyOfferingBuyEnd));
        public static readonly TransactionType CurrencyOfferingSellBegin = new TransactionType("913", "Продажа CurrencyOffering начало", nameof(CurrencyOfferingSellBegin));
        public static readonly TransactionType CurrencyOfferingSellEnd = new TransactionType("914", "Продажа CurrencyOffering конец", nameof(CurrencyOfferingSellEnd));
        public static readonly TransactionType CurrencyOfferingCommission = new TransactionType("917", "Комиссия покупки CurrencyOffering", nameof(CurrencyOfferingCommission));
        public static readonly TransactionType CurrencyOfferingTransfer = new TransactionType("919", "Разблокировка после покупки CurrencyOffering", nameof(CurrencyOfferingTransfer));


        public static readonly TransactionType BwpInvoiceCryptoBlockBegin = new TransactionType("701", "Bwp крипто-блокировка по инвоису начало", nameof(BwpInvoiceCryptoBlockBegin));
        public static readonly TransactionType BwpInvoiceCryptoBlockEnd = new TransactionType("702", "Bwp крипто-блокировка по инвоису конец", nameof(BwpInvoiceCryptoBlockEnd));
        public static readonly TransactionType BwpInvoiceCryptoBlockCancelBegin = new TransactionType("703", "Bwp отмена крипто-блокировки по инвоису начало", nameof(BwpInvoiceCryptoBlockCancelBegin));
        public static readonly TransactionType BwpInvoiceCryptoBlockCancelEnd = new TransactionType("704", "Bwp отмена крипто-блокировки по инвоису конец", nameof(BwpInvoiceCryptoBlockCancelEnd));
        public static readonly TransactionType BwpInvoiceCryptoBlockCorrection = new TransactionType("705", "Bwp корректировки крипто-блокировки по инвоису", nameof(BwpInvoiceCryptoBlockCorrection));

        public static readonly TransactionType BwpFiatPaymentToTrader = new TransactionType("711", "Bwp фиат-оплата трейдеру", nameof(BwpFiatPaymentToTrader));
        public static readonly TransactionType BwpCryptoPaymentToMerchantBegin = new TransactionType("715", "Bwp крипто-оплата мерчанту начало", nameof(BwpCryptoPaymentToMerchantBegin));
        public static readonly TransactionType BwpCryptoPaymentToMerchantEnd = new TransactionType("716", "Bwp крипто-оплата мерчанту конец", nameof(BwpCryptoPaymentToMerchantEnd));
        public static readonly TransactionType BwpMerchantFee = new TransactionType("721", "Bwp комиссия с мерчанта", nameof(BwpMerchantFee));
        public static readonly TransactionType BwpTraderProfit = new TransactionType("722", "Bwp прибыль трейдеру", nameof(BwpTraderProfit));

        // Block can happen on order creation or on deal creation, depending on buying or selling crypto
        public static readonly TransactionType P2pOrderBlockBegin = new TransactionType("751", "P2P блокировка для ордера начало", nameof(P2pOrderBlockBegin));
        public static readonly TransactionType P2pOrderBlockEnd = new TransactionType("752", "P2P блокировка для ордера конец", nameof(P2pOrderBlockEnd));
        public static readonly TransactionType P2pOrderBlockCancelBegin = new TransactionType("753", "P2P отмена блокировки для ордера начало", nameof(P2pOrderBlockCancelBegin));
        public static readonly TransactionType P2pOrderBlockCancelEnd = new TransactionType("754", "P2P отмена блокировки для ордера конец", nameof(P2pOrderBlockCancelEnd));
        public static readonly TransactionType P2pOrderRemainingBlockCancelBegin = new TransactionType("755", "P2P отмена оставшейся блокировки для ордера после сделки начало", nameof(P2pOrderRemainingBlockCancelBegin));
        public static readonly TransactionType P2pOrderRemainingBlockCancelEnd = new TransactionType("756", "P2P отмена оставшейся блокировки для ордера после сделки конец", nameof(P2pOrderRemainingBlockCancelEnd));
        public static readonly TransactionType P2pOrderFeeBegin = new TransactionType("757", "P2P комиссия от ордера после завершения сделки начало", nameof(P2pOrderFeeBegin));
        public static readonly TransactionType P2pOrderFeeEnd = new TransactionType("758", "P2P комиссия от ордера после завершения сделки конец", nameof(P2pOrderFeeEnd));

        public static readonly TransactionType P2pDealBlockBegin = new TransactionType("761", "P2P блокировка для сделки начало", nameof(P2pDealBlockBegin));
        public static readonly TransactionType P2pDealBlockEnd = new TransactionType("762", "P2P блокировка для сделки конец", nameof(P2pDealBlockEnd));
        public static readonly TransactionType P2pDealBlockCancelBegin = new TransactionType("763", "P2P отмена блокировки для сделки начало", nameof(P2pDealBlockCancelBegin));
        public static readonly TransactionType P2pDealBlockCancelEnd = new TransactionType("764", "P2P отмена блокировки для сделки конец", nameof(P2pDealBlockCancelEnd));

        public static readonly TransactionType P2pTransferFromOrderBegin = new TransactionType("771", "P2P перевод средств из ордера начало", nameof(P2pTransferFromOrderBegin));
        public static readonly TransactionType P2pTransferFromOrderEnd = new TransactionType("772", "P2P перевод средств из ордера конец", nameof(P2pTransferFromOrderEnd));
        public static readonly TransactionType P2pTransferFromDealBegin = new TransactionType("773", "P2P перевод средств из сделки начало", nameof(P2pTransferFromDealBegin));
        public static readonly TransactionType P2pTransferFromDealEnd = new TransactionType("774", "P2P перевод средств из сделки конец", nameof(P2pTransferFromDealEnd));
        public static readonly TransactionType P2pDealFee = new TransactionType("777", "P2P комиссия после завершения сделки", nameof(P2pDealFee));

        public static readonly TransactionType P2pExternalFiatTransfer = new TransactionType("7501", "P2P перевод фиата вне биржи", nameof(P2pExternalFiatTransfer));

        public static readonly List<TransactionType> TradingTypes = new List<TransactionType>
        {
            Rollback,
            OrderingBegin, OrderingEnd,
            OrderCancellingBegin, OrderCancellingEnd,
            OrderExcessCancellingBegin, OrderExcessCancellingEnd,
            Transfer, TransferBegin, TransferEnd,
            OrderingReturnRemains,
        };

        public static readonly List<TransactionType> All = new List<TransactionType>
        {
            Rollback,

            Deposit, DepositAdmin, DepositStaking, DepositAirdrop, DepositToFunds, DepositReplacement, DepositCorrection,

            Nullification, Confiscation,

            WithdrawalBlockBegin, WithdrawalBlockEnd,
            WithdrawalStockCommissionBlockBegin, WithdrawalStockCommissionBlockEnd,
            WithdrawalBlockCancelBegin, WithdrawalBlockCancelEnd,
            WithdrawalStockCommissionBlockCancelBegin, WithdrawalStockCommissionBlockCancelEnd,
            WithdrawalBegin, WithdrawalEnd,
            WithdrawalStockCommissionBegin, WithdrawalStockCommissionEnd,
            WithdrawalNetworkCommission,
            WithdrawalBlockRollback, WithdrawalStockCommissionBlockRollback,

            TransferToColdWallet,

            OrderingBegin, OrderingEnd,
            OrderCancellingBegin, OrderCancellingEnd,
            OrderExcessCancellingBegin, OrderExcessCancellingEnd,
            Transfer, TransferBegin, TransferEnd,
            OrderingReturnRemains,

            Fee, NodeAgregationNetworkCommission,

            BotDeposit, BotWithdrawal, BotCommission, BotProfit, BotTransferFromUser, BotTransferToUser,
            DealsBotTransferFromUser, DealsBotTransferToUser,

            InternalTransfer,
            ExchangeTransfer, ExchangeTransferBegin, ExchangeTransferEnd,
            ExchangeMarkup, ExchangeCommission, ExchangeCommissionConsolidation,

            AffiliateTariffPurchase, AffiliateTariffPurchaseRollback,
            AffiliateDealCommission, AffiliateWithdrawalCommission, AffiliateCurrencyListing, AffiliateApiTradeProfitPayment,
            AffiliateClear,
            AffiliateProfitPayment, AffiliateBonusesPayment,

            BountyDistributionDeposit, BountyBonusesPayment,

            PaymentCardPurchase,

            StakingFundProfit, StakingLock, StakingUnlockBegin, StakingUnlockEnd,

            CurrencyListingDeployPayment, CurrencyListingDealFeeProfit,

            ApiTradeProfitPayment,

            CurrencyOfferingBuyBegin, CurrencyOfferingBuyEnd, CurrencyOfferingSellBegin, CurrencyOfferingSellEnd,
            CurrencyOfferingCommission, CurrencyOfferingTransfer,

            BwpInvoiceCryptoBlockBegin, BwpInvoiceCryptoBlockEnd, BwpInvoiceCryptoBlockCancelBegin, BwpInvoiceCryptoBlockCancelEnd,
            BwpInvoiceCryptoBlockCorrection,
            BwpFiatPaymentToTrader,
            BwpCryptoPaymentToMerchantBegin, BwpCryptoPaymentToMerchantEnd, BwpMerchantFee, BwpTraderProfit,

            P2pOrderBlockBegin, P2pOrderBlockEnd,
            P2pOrderBlockCancelBegin, P2pOrderBlockCancelEnd, P2pOrderRemainingBlockCancelBegin, P2pOrderRemainingBlockCancelEnd,
            P2pOrderFeeBegin, P2pOrderFeeEnd,

            P2pDealBlockBegin, P2pDealBlockEnd,
            P2pDealBlockCancelBegin, P2pDealBlockCancelEnd,
            P2pTransferFromOrderBegin, P2pTransferFromOrderEnd, P2pTransferFromDealBegin, P2pTransferFromDealEnd,
            P2pDealFee,
            P2pExternalFiatTransfer,
        };

        private TransactionType(string code, string value, string valueKey)
        {
            Code = code;
            Value = value;
            ValueKey = valueKey;
        }

        public TransactionType()
        {
        }
    }
}
