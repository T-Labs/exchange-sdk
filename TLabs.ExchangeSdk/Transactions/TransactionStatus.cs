using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Transactions
{
    public enum TransactionStatus
    {
        /// <summary>
        /// Sent to blockchain, not included in block yet
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Error in blockchain
        /// </summary>
        Error = 4,

        /// <summary>
        /// Confirmed in blockchain and saved in Depository
        /// </summary>
        Received = 5,

        /// <summary>
        /// Canceled
        /// </summary>
        Canceled = 6,

        /// <summary>
        /// Fail Notified
        /// </summary>
        FailNotified = 7,

        /// <summary>
        /// Fail send by admin
        /// </summary>
        FailSetByAdmin = 8
    }
}
