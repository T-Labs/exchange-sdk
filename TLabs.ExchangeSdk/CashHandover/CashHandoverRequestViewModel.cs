using System;
using Microsoft.AspNetCore.Http;

namespace TLabs.ExchangeSdk.CashHandover;

public class CashHandoverRequestViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ClientName { get; set; }
    public decimal Amount { get; set; }
    public IFormFile PayoutImage { get; set; }
    public CashHandoverRequestStatus Status { get; set; }
}
