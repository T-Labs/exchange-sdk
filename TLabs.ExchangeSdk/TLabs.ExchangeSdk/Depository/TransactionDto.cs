using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Depository
{
    public class TransactionDto
    {
        /// <summary>
        /// Transaction guid
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Transaction number
        /// </summary>
        public string TxId { get; set; }

        /// <summary>
        /// Busines process id
        /// In order reservation - order Id
        /// </summary>
        public string ActionId { get; set; }

        /// <summary>
        /// Date created
        /// </summary>
        public DateTimeOffset Datetime { get; set; }

        /// <summary>
        /// Transaction type
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Recipient
        /// </summary>
        public AccountDto RecipientAccount { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public AccountDto SenderAccount { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Id of related deal (nullable)
        /// </summary>
        public string DealId { get; set; }
    }
}
