using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Depository
{
    public class AccountChart
    {
        [Key]
        public string Code { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// Key for localization
        /// </summary>
        public string ValueKey { get; set; }

        public static readonly AccountChart Users = new AccountChart("1", "Средства пользователей", nameof(Users));

        public static readonly AccountChart FundsDeposit = new AccountChart("38", "Пополнение фондов", nameof(FundsDeposit));
        public static readonly AccountChart FundsWithdrawal = new AccountChart("39", "Выводы из фондов", nameof(FundsWithdrawal));
        public static readonly AccountChart Funds = new AccountChart("3", "Фонды", nameof(Funds));
        public static readonly AccountChart NodeAgregationFunds = new AccountChart("31", "Фонды агрегации средств ноды", nameof(NodeAgregationFunds));
        public static readonly AccountChart WithdrawalNetworkCommissionFunds = new AccountChart("32", "Фонды служебных расходов на комиссию сети вывода", nameof(WithdrawalNetworkCommissionFunds));
        public static readonly AccountChart FundAffiliateBonusesForDistribution = new AccountChart("346", "Фонд Affiliate бонусов для распределения", nameof(FundAffiliateBonusesForDistribution));
        public static readonly AccountChart FundAffiliateProfits = new AccountChart("347", "Фонд Affiliate прибыли", nameof(FundAffiliateProfits));
        public static readonly AccountChart FundAffiliateProfitsStaking = new AccountChart("348", "Фонд Affiliate прибыли по стейкингам", nameof(FundAffiliateProfitsStaking));
        public static readonly AccountChart FundBountyBonusesForDistribution = new AccountChart("349", "Фонд BuySell бонусов для распределения", nameof(FundBountyBonusesForDistribution));
        public static readonly AccountChart FundPaymentsComission = new AccountChart("351", "Фонд комиссий платежей", nameof(FundPaymentsComission));
        public static readonly AccountChart Nullification = new AccountChart("359", "Обнуление баланса", nameof(Nullification));

        public static readonly AccountChart FundBot = new AccountChart("361", "Фонды бота", nameof(FundBot));
        public static readonly AccountChart FundBotProfits = new AccountChart("362", "Фонды прибыли бота", nameof(FundBotProfits));

        public static readonly AccountChart FundTradingBot = new AccountChart("371", "Фонды трейдинг бота", nameof(FundTradingBot));
        public static readonly AccountChart FundLiquidityBot = new AccountChart("372", "Фонды бота ликвидности", nameof(FundLiquidityBot));

        public static readonly AccountChart Deposit = new AccountChart("5", "Введеные средства", nameof(Deposit));
        public static readonly AccountChart DepositAdmin = new AccountChart("51", "Введеные средства админом", nameof(DepositAdmin));
        public static readonly AccountChart DepositCash = new AccountChart("52", "Введеные средства наличными", nameof(DepositCash));
        public static readonly AccountChart DepositAirdrop = new AccountChart("53", "Введеные средства аирдропом", nameof(DepositAirdrop));
        public static readonly AccountChart DepositStaking = new AccountChart("54", "Введеные средства стейкингом", nameof(DepositStaking));
        public static readonly AccountChart DepositStakingAffiliate = new AccountChart("55", "Введеные средства партнерке по стейкингу", nameof(DepositStakingAffiliate));
        public static readonly AccountChart DepositToFunds = new AccountChart("56", "Введеные средства на фонды", nameof(DepositToFunds));
        public static readonly AccountChart DepositReplacement = new AccountChart("58", "Введеные средства взамен удаленной валюты", nameof(DepositReplacement));
        public static readonly AccountChart DepositCorrection = new AccountChart("59", "Корректировочное пополнение баланса", nameof(DepositCorrection));

        public static readonly AccountChart WithdrawalBlockedTemp = new AccountChart("61", "Заморозка средств к выводу временная", nameof(WithdrawalBlockedTemp));
        public static readonly AccountChart WithdrawalBlocked = new AccountChart("6", "Заморозка средств к выводу", nameof(WithdrawalBlocked));
        public static readonly AccountChart WithdrawalBlockCanceledTemp = new AccountChart("63", "Отмена заморозки средств к выводу временная", nameof(WithdrawalBlockCanceledTemp));
        public static readonly AccountChart WithdrawnTemp = new AccountChart("65", "Выведенные средства временная", nameof(WithdrawnTemp));
        public static readonly AccountChart Withdrawn = new AccountChart("4", "Выведенные средства", nameof(Withdrawn));
        public static readonly AccountChart WithdrawalStockCommissionTemp = new AccountChart("67", "Комиссия успешного вывода временная", nameof(WithdrawalStockCommissionTemp));

        public static readonly AccountChart BlockedForExchangeTransfer = new AccountChart("431", "Заморозка средств при ExchangeTransfer", nameof(BlockedForExchangeTransfer));

        public static readonly AccountChart BlockedForOrder = new AccountChart("7", "Заморозка средств на ордер", nameof(BlockedForOrder));
        public static readonly AccountChart BlockedForCancelOrder = new AccountChart("71", "Заморозка средств при отмене ордера", nameof(BlockedForCancelOrder));
        public static readonly AccountChart BlockedForDeal = new AccountChart("73", "Заморозка средств при сделке", nameof(BlockedForDeal));
        public static readonly AccountChart OnOrders = new AccountChart("75", "Средства на ордерах", nameof(OnOrders));

        public static readonly AccountChart NetworkComission = new AccountChart("8", "Комиссия блокчейна", nameof(NetworkComission));
        public static readonly AccountChart ColdWallets = new AccountChart("11", "Холодные кошельки", nameof(ColdWallets));

        public static readonly AccountChart StakingLocked = new AccountChart("855", "Стейкинг замороженные средства", nameof(StakingLocked));
        public static readonly AccountChart StakingLockedTemp = new AccountChart("856", "Стейкинг замороженные средства", nameof(StakingLockedTemp));
        public static readonly AccountChart StakingUnlockedTemp = new AccountChart("857", "Стейкинг замороженные средства", nameof(StakingUnlockedTemp));

        public static readonly AccountChart CurrencyListingPaymentBlocked = new AccountChart("871", "CurrencyListing блокировка оплаты", nameof(CurrencyListingPaymentBlocked));

        public static readonly AccountChart CurrencyOfferingsBlocked = new AccountChart("901", "Этап блокировки на CurrencyOffering", nameof(CurrencyOfferingsBlocked));
        public static readonly AccountChart CurrencyOfferingsVesting = new AccountChart("903", "Вестинг на CurrencyOffering", nameof(CurrencyOfferingsVesting));

        public static readonly AccountChart BwpInvoiceCryptoBlockedTemp = new AccountChart("701", "Bwp крипто-блокировка по инвоису временная", nameof(BwpInvoiceCryptoBlockedTemp));
        public static readonly AccountChart BwpInvoiceCryptoBlocked = new AccountChart("702", "Bwp крипто-блокировка по инвоису", nameof(BwpInvoiceCryptoBlocked));
        public static readonly AccountChart BwpInvoiceCryptoBlockCanceledTemp = new AccountChart("703", "Bwp отмена крипто-блокировки по инвоису временная", nameof(BwpInvoiceCryptoBlockCanceledTemp));
        public static readonly AccountChart BwpCryptoPaymentToMerchantTemp = new AccountChart("715", "Bwp крипто-оплата мерчанту заморозка", nameof(BwpCryptoPaymentToMerchantTemp));

        // Block can happen on order creation or on deal creation, depending on buying or selling crypto
        public static readonly AccountChart P2pOrderBlockedTemp = new AccountChart("751", "P2P блокировка для ордера временная", nameof(P2pOrderBlockedTemp));
        public static readonly AccountChart P2pOrderBlocked = new AccountChart("752", "P2P блокировка для ордера", nameof(P2pOrderBlocked));
        public static readonly AccountChart P2pOrderBlockCanceledTemp = new AccountChart("753", "P2P отмена блокировки для ордера временная", nameof(P2pOrderBlockCanceledTemp));
        public static readonly AccountChart P2pOrderFeeTemp = new AccountChart("757", "P2P комиссия ордера временная", nameof(P2pOrderFeeTemp));

        public static readonly AccountChart P2pDealBlockedTemp = new AccountChart("761", "P2P блокировка для сделки временная", nameof(P2pDealBlockedTemp));
        public static readonly AccountChart P2pDealBlocked = new AccountChart("762", "P2P блокировка для сделки", nameof(P2pDealBlocked));
        public static readonly AccountChart P2pDealBlockCanceledTemp = new AccountChart("763", "P2P отмена блокировки для сделки временная", nameof(P2pDealBlockCanceledTemp));
        public static readonly AccountChart P2pTransferFromOrderTemp = new AccountChart("771", "P2P перевод из ордера временный", nameof(P2pTransferFromOrderTemp));
        public static readonly AccountChart P2pTransferFromDealTemp = new AccountChart("772", "P2P перевод из сделки временный", nameof(P2pTransferFromDealTemp));

        // Accounts for P2P fiat transfers (happen outside of the exchange)
        public static readonly AccountChart P2pExternalPaymentSource = new AccountChart("7501", "P2P внешний счет источника фиата", nameof(P2pExternalPaymentSource));
        public static readonly AccountChart P2pExternalPaymentDestination = new AccountChart("7502", "P2P внешний счет получателя фиата", nameof(P2pExternalPaymentDestination));

        /// <summary>Accounts that have UserId</summary>
        public static readonly List<AccountChart> UsersPersonalCharts = new List<AccountChart>
        {
            Users,
            BlockedForExchangeTransfer,
            BlockedForOrder, BlockedForCancelOrder, BlockedForDeal, OnOrders,
            WithdrawalBlockedTemp, WithdrawalBlocked, WithdrawalBlockCanceledTemp, WithdrawnTemp, WithdrawalStockCommissionTemp,
            StakingLocked, StakingLockedTemp, StakingUnlockedTemp,
            CurrencyListingPaymentBlocked,
            CurrencyOfferingsBlocked, CurrencyOfferingsVesting,

            FundBot, FundTradingBot,FundLiquidityBot,

            BwpInvoiceCryptoBlockedTemp, BwpInvoiceCryptoBlocked, BwpInvoiceCryptoBlockCanceledTemp,
            BwpCryptoPaymentToMerchantTemp,

            P2pOrderBlockedTemp, P2pOrderBlocked, P2pOrderBlockCanceledTemp,
            P2pOrderFeeTemp,
            P2pDealBlockedTemp, P2pDealBlocked, P2pDealBlockCanceledTemp,
            P2pTransferFromOrderTemp, P2pTransferFromDealTemp,
            P2pExternalPaymentSource, P2pExternalPaymentDestination,
        };

        public static readonly List<AccountChart> All = new List<AccountChart>(UsersPersonalCharts)
        {
            Funds,
            FundAffiliateBonusesForDistribution, FundAffiliateProfits, FundAffiliateProfitsStaking,
            FundBotProfits, FundPaymentsComission, FundsDeposit, FundsWithdrawal,
            FundBountyBonusesForDistribution,
            Nullification,

            Deposit, DepositAdmin, DepositCash, DepositStaking, DepositStakingAffiliate, DepositAirdrop, DepositToFunds,
            DepositReplacement, DepositCorrection,

            Withdrawn,
            ColdWallets,
            NetworkComission, WithdrawalNetworkCommissionFunds,
            NodeAgregationFunds,
        };

        public static readonly List<AccountChart> DepositCharts = new List<AccountChart>
        {
            Deposit, DepositAdmin, DepositCash, DepositStaking, DepositAirdrop, DepositToFunds,
            DepositReplacement, DepositCorrection,
        };

        public static readonly List<AccountChart> ChartsWithAdapterCode = new List<AccountChart>
        {
            Deposit, DepositToFunds, Withdrawn, NetworkComission,
        };

        private AccountChart(string code, string value, string valueKey)
        {
            Code = code;
            Value = value;
            ValueKey = valueKey;
        }

        public AccountChart()
        {
        }
    }
}
