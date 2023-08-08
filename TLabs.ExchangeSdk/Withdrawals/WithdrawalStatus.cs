using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class WithdrawalStatus
    {
        /// <summary>
        /// Code
        /// </summary>
        [Key]
        public int Code { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Key for localization
        /// </summary>
        public string ValueKey { get; set; }

        private WithdrawalStatus(int code, string value, string valueKey)
        {
            Code = code;
            Value = value;
            ValueKey = valueKey;
        }

        public WithdrawalStatus()
        {
        }

        public static readonly WithdrawalStatus Created = new WithdrawalStatus(1, "Создано", "Created");
        public static readonly WithdrawalStatus AwaitsApproval = new WithdrawalStatus(2, "Ожидание подтверждения", "AwaitsApproval");

        /// <summary>delay to prevent same txHash error; will be sent soon</summary>
        public static readonly WithdrawalStatus Postponed = new WithdrawalStatus(10, "Отложено", nameof(Postponed));

        /// <summary>sent to blockchain but not confirmed yet</summary>
        public static readonly WithdrawalStatus Sent = new WithdrawalStatus(3, "Отправлено", "Sent");

        /// <summary>error, can be resent</summary>
        public static readonly WithdrawalStatus Error = new WithdrawalStatus(4, "Ошибка", "Error");

        /// <summary>finished</summary>
        public static readonly WithdrawalStatus Confirmed = new WithdrawalStatus(5, "Подтверждено сетью", "Confirmed");

        /// <summary>canceled</summary>
        public static readonly WithdrawalStatus Declined = new WithdrawalStatus(6, "Отклонено", "Declined");

        public static readonly List<WithdrawalStatus> All = new List<WithdrawalStatus>
        {
            Created, AwaitsApproval, Postponed, Sent, Error, Confirmed, Declined
        };

        public static WithdrawalStatus GetWithdrawalStatusByCode(int code)
            => All.First(_ => _.Code == code);
    }
}
