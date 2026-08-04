using System;

namespace TLabs.ExchangeSdk.Verification;

/// <summary>
/// Complete editable KYC snapshot submitted by an administrator.
/// Empty values intentionally clear the corresponding stored values.
/// </summary>
public class AdminVerificationUpdateDto
{
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string MiddleName { get; set; }
    public int? CitizenshipId { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Skype { get; set; }
    public int? CountryResidenceId { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string DocumentNumber { get; set; }
    public DateTimeOffset? DocumentDateIssued { get; set; }
    public DateTimeOffset? DocumentDateExpire { get; set; }
    public string ProofOfAddress { get; set; }
    public int? TypeProofOfAddressId { get; set; }
    public int? TypeIdentityCardId { get; set; }
    public string IdentityCard { get; set; }
    public string IdentityCardBackside { get; set; }
    public string PhotoWithDocument { get; set; }
    public string UserAuthenticationVideo { get; set; }
    public bool ApplicationFromExchanger { get; set; }
}
