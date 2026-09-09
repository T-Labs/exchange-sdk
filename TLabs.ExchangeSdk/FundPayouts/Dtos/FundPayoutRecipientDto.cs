using System.Collections.Generic;

namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class FundPayoutRecipientDto
    {
        public string UserId { get; set; }

        public List<FundPayoutAddressDto> Addresses { get; set; } = new List<FundPayoutAddressDto>();
    }
}
