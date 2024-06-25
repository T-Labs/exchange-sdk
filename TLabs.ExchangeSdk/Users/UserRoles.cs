using System;
using System.Collections.Generic;
using System.Linq;

namespace TLabs.ExchangeSdk.Users
{
    public class UserRoles
    {
        public const string Admin = "Administrator";
        public const string Manager = "Manager";
        public const string SupportFull = "Support Full";
        public const string KYC = "KYC";
        public const string ColdWallets = "Cold Wallets";
        public const string CashOperations = "Cash operations";
        public const string TokensAndCommissions = "Setting tokens and commissions";

        public const string FinancialReports = "Financial reports";
        public const string ContentMaker = "Content maker";
        public const string ApitradeReadonly = "ApitradeReadonly";
        public const string ApitradeAdmin = "ApitradeAdmin";
        public const string P2PWatch = "P2PWatch";
        public const string P2PAppealManager = "P2PAppealManager";
        public const string TokenCreator = "TokenCreator";

        /// <summary>Unused</summary>
        public const string CommonQuestions = "Common questions";

        public static List<string> AllRoles = new List<string>
        {
            Admin, Manager, SupportFull, KYC, ColdWallets, CashOperations, TokensAndCommissions,
            FinancialReports, ContentMaker, ApitradeReadonly, ApitradeAdmin, CommonQuestions, P2PWatch, P2PAppealManager,
            TokenCreator,
        };
    }
}
