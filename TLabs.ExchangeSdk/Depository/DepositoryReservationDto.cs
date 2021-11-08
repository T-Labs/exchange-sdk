using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Depository
{
    public enum DepositoryReservationType
    {
        CreateOrder = 1, CancelOrder
    }

    public class DepositoryReservationDto
    {
        public DepositoryReservationType ReservationType { get; set; }
        public string ActionId { get; set; }
        public ClientType ClientType { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
