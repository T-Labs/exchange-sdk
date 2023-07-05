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
        public static readonly TransactionType DepositReplacement = new TransactionType("108", "Пополнение баланса взамен удаленной валюты", nameof(DepositReplacement));
        public static readonly TransactionType DepositCorrection = new TransactionType("109", "Корректировочное пополнение баланса", nameof(DepositCorrection));
        public static readonly TransactionType Nullification = new TransactionType("121", "Обнуление баланса", nameof(Nullification));

        public static readonly TransactionType WithdrawalBlock = new TransactionType("06", "Блокировка для вывода", nameof(WithdrawalBlock));
        public static readonly TransactionType WithdrawalStockCommissionBlock = new TransactionType("061", "Блокировка комиссии биржи для вывода", nameof(WithdrawalStockCommissionBlock));
        public static readonly TransactionType WithdrawalBlockRollback = new TransactionType("063", "Откат блокировки для вывода", nameof(WithdrawalBlockRollback));
        public static readonly TransactionType WithdrawalStockCommissionBlockRollback = new TransactionType("064", "Откат блокировки комиссии биржи для вывода", nameof(WithdrawalStockCommissionBlockRollback));
        public static readonly TransactionType WithdrawalBlockCancel = new TransactionType("065", "Отмена блокировки для вывода", nameof(WithdrawalBlockCancel));
        public static readonly TransactionType WithdrawalStockCommissionBlockCancel = new TransactionType("066", "Отмена блокировки комиссии биржи для вывода", nameof(WithdrawalStockCommissionBlockCancel));
        public static readonly TransactionType Withdrawal = new TransactionType("05", "Вывод средств", nameof(Withdrawal));
        public static readonly TransactionType WithdrawalStockCommission = new TransactionType("062", "Комиссия вывода биржи", nameof(WithdrawalStockCommission));
        public static readonly TransactionType WithdrawalNetworkCommission = new TransactionType("07", "Комиссия вывода блокчейна", nameof(WithdrawalNetworkCommission));

        public static readonly TransactionType WithdrawalCashBlockBegin = new TransactionType("0601", "Блокировка для вывода наличных начало", nameof(WithdrawalCashBlockBegin));
        public static readonly TransactionType WithdrawalCashBlockEnd = new TransactionType("0602", "Блокировка для вывода наличных конец", nameof(WithdrawalCashBlockEnd));
        public static readonly TransactionType WithdrawalCashCompletionBegin = new TransactionType("0603", "Исполнение вывода наличных начало", nameof(WithdrawalCashCompletionBegin));
        public static readonly TransactionType WithdrawalCashCompletionEnd = new TransactionType("0604", "Исполнение вывода наличных конец", nameof(WithdrawalCashCompletionEnd));
        public static readonly TransactionType WithdrawalCashCancelBegin = new TransactionType("0605", "Отмена вывода наличных начало", nameof(WithdrawalCashCancelBegin));
        public static readonly TransactionType WithdrawalCashCancelEnd = new TransactionType("0606", "Отмена вывода наличных конец", nameof(WithdrawalCashCancelEnd));
        public static readonly TransactionType WithdrawalCashCommission = new TransactionType("0609", "Комиссия вывода наличных начало", nameof(WithdrawalCashCommission));

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

        public static readonly TransactionType CurrencyListingPaymentBlock = new TransactionType("871", "CurrencyListing блокировка оплаты", nameof(CurrencyListingPaymentBlock));
        public static readonly TransactionType CurrencyListingPaymentCancel = new TransactionType("872", "CurrencyListing отмена оплаты", nameof(CurrencyListingPaymentCancel));
        public static readonly TransactionType CurrencyListingPayment = new TransactionType("873", "CurrencyListing оплата", nameof(CurrencyListingPayment));

        public static readonly TransactionType ApiTradeProfitPayment = new TransactionType("891", "Оплата за прибыль ApiTrade", nameof(ApiTradeProfitPayment));

        public static readonly TransactionType CurrencyOfferingBuyBegin = new TransactionType("911", "Покупка CurrencyOffering начало", nameof(CurrencyOfferingBuyBegin));
        public static readonly TransactionType CurrencyOfferingBuyEnd = new TransactionType("912", "Покупка CurrencyOffering конец", nameof(CurrencyOfferingBuyEnd));
        public static readonly TransactionType CurrencyOfferingSellBegin = new TransactionType("913", "Продажа CurrencyOffering начало", nameof(CurrencyOfferingSellBegin));
        public static readonly TransactionType CurrencyOfferingSellEnd = new TransactionType("914", "Продажа CurrencyOffering конец", nameof(CurrencyOfferingSellEnd));
        public static readonly TransactionType CurrencyOfferingCommission = new TransactionType("917", "Комиссия покупки CurrencyOffering", nameof(CurrencyOfferingCommission));
        public static readonly TransactionType CurrencyOfferingTransfer = new TransactionType("919", "Разблокировка после покупки CurrencyOffering", nameof(CurrencyOfferingTransfer));

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

            Deposit, DepositAdmin, DepositStaking, DepositAirdrop, DepositReplacement, DepositCorrection,
            Nullification,

            WithdrawalBlock, WithdrawalStockCommissionBlock,
            WithdrawalBlockRollback, WithdrawalStockCommissionBlockRollback,
            WithdrawalBlockCancel, WithdrawalStockCommissionBlockCancel,
            Withdrawal, WithdrawalStockCommission, WithdrawalNetworkCommission,

            WithdrawalCashBlockBegin, WithdrawalCashBlockEnd, WithdrawalCashCompletionBegin, WithdrawalCashCompletionEnd,
            WithdrawalCashCancelBegin, WithdrawalCashCancelEnd, WithdrawalCashCommission,

            TransferToColdWallet,

            OrderingBegin, OrderingEnd,
            OrderCancellingBegin, OrderCancellingEnd,
            OrderExcessCancellingBegin, OrderExcessCancellingEnd,
            Transfer, TransferBegin, TransferEnd,
            OrderingReturnRemains,

            Fee, NodeAgregationNetworkCommission,

            BotDeposit, BotWithdrawal, BotCommission, BotProfit, BotTransferFromUser, BotTransferToUser,

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

            CurrencyListingPaymentBlock, CurrencyListingPayment, CurrencyListingPaymentCancel,

            ApiTradeProfitPayment,

            CurrencyOfferingBuyBegin, CurrencyOfferingBuyEnd, CurrencyOfferingSellBegin, CurrencyOfferingSellEnd,
            CurrencyOfferingCommission, CurrencyOfferingTransfer,
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
