using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.RabbitMq
{
    /// <summary>Affiliate Message that indicates user's registration</summary>
    public class UserRegisteredMessage : Message
    {
        /// <summary>Id registered user</summary>
        public string UserId { get; set; }

        /// <summary>Code with which user has registered</summary>
        public string InviteCode { get; set; }
    }
}
