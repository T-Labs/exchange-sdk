using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.RabbitMq
{
    public class EmailTemplateSender
    {
        private readonly RabbitMqSender _sender;
        private readonly ILogger _logger;

        public EmailTemplateSender(RabbitMqSender sender,
            ILogger<EmailTemplateSender> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public QueryResult SendRegisterConfirmationEmail(string email, string language, string callbackUrl)
        {
            return _sender.SendEmailTemplate(email, "ConfirmEmail", new Dictionary<string, string>
            {
                { "confirmUrl", callbackUrl }
            }, language);
        }

        public QueryResult SendResetPasswordEmail(string email, string language, string callbackUrl)
        {
            return _sender.SendEmailTemplate(email, "ResetPassword", new Dictionary<string, string>
            {
                { "confirmUrl", callbackUrl }
            }, language);
        }

        [Obsolete("Username not used anymore")]
        public QueryResult SendRemindUsernameEmail(string email, string language, string userName)
        {
            return _sender.SendEmailTemplate(email, "RemindUsername", new Dictionary<string, string>
            {
                { "userName", userName }
            }, language);
        }

        public QueryResult SendTwoFactorCodeEmail(string email, string language, string code)
        {
            return _sender.SendEmailTemplate(email, "2faCode", new Dictionary<string, string>
            {
                { "verificationCode", code }
            }, language);
        }

        public QueryResult SendVerificationConfirmedEmail(string email, string language)
        {
            return _sender.SendEmailTemplate(email, "VerificationConfirmed", null, language);
        }

        public QueryResult SendVerificationRejectedEmail(string email, string language, string reason)
        {
            return _sender.SendEmailTemplate(email, "VerificationRejected", new Dictionary<string, string>
            {
                { "reason", reason }
            }, language);
        }

        public QueryResult SendDepositSuccess(string email, string language,
            decimal amount, string currencyCode)
        {
            return _sender.SendEmailTemplate(email, "DepositSuccess", new Dictionary<string, string>
            {
                { nameof(amount), amount.ToString() },
                { nameof(currencyCode), currencyCode },
            }, language);
        }

        public QueryResult SendWithdrawalVerificationCode(string email, string language,
            string verificationCode, decimal amount, string currency, string addressTo, string userIP)
        {
            return _sender.SendEmailTemplate(email, "WithdrawalVerificationCode", new Dictionary<string, string>
            {
                { nameof(verificationCode), verificationCode },
                { nameof(amount), amount.ToString() },
                { nameof(currency), currency },
                { nameof(addressTo), addressTo },
                { nameof(userIP), userIP },
            }, language);
        }

        public QueryResult SendWithdrawalVerificationCodeCash(string email, string language,
            string verificationCode, decimal amount, string currency, string addressTo, string userIP)
        {
            return _sender.SendEmailTemplate(email, "WithdrawalVerificationCodeCash", new Dictionary<string, string>
            {
                { nameof(verificationCode), verificationCode },
                { nameof(amount), amount.ToString() },
                { nameof(currency), currency },
                { nameof(addressTo), addressTo },
                { nameof(userIP), userIP },
            }, language);
        }

        public QueryResult SendWithdrawalSuccess(string email, string language,
            decimal amount, string currencyCode, string adapterCode, string address, string txId)
        {
            return _sender.SendEmailTemplate(email, "WithdrawalSuccess", new Dictionary<string, string>
            {
                { nameof(amount), amount.ToString() },
                { nameof(currencyCode), currencyCode },
                { nameof(adapterCode), adapterCode },
                { nameof(address), address },
                { nameof(txId), txId },
            }, language);
        }

        public QueryResult SendWithdrawalSuccessCash(string email, string language,
            decimal amount, string currencyCode)
        {
            return _sender.SendEmailTemplate(email, "WithdrawalSuccessCash", new Dictionary<string, string>
            {
                { nameof(amount), amount.ToString() },
                { nameof(currencyCode), currencyCode },
            }, language);
        }

        public QueryResult SendGoogle2FAEmailCode(string email, string language, string code, int codeLifetime)
        {
            return _sender.SendEmailTemplate(email, "Google2FAEmailCode", new Dictionary<string, string>
            {
                { "CodeLifetime", codeLifetime.ToString() },
                { "VerificationCode", code }
            }, language);
        }
    }
}
