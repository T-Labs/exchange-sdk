using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.RabbitMq
{
    public abstract class Message
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    }
}
