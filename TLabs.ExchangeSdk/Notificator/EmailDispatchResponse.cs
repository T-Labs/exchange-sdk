using System;

namespace TLabs.ExchangeSdk.Notificator
{
    public class EmailDispatchResponse
    {
        public Guid Id { get; set; }

        public string Status { get; set; }

        public string Error { get; set; }
    }
}
