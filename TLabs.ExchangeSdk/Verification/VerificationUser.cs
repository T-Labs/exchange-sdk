using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Verification
{
    public class VerificationUser
    {
        public string Id { get; set; }
        public UserVerificationStage VerificationStage { get; set; }
        public StatusVerificationUser Status { get; set; } = StatusVerificationUser.Success;

        /// <summary> Administrator's comment when changing the profile status </summary>
        public string StatusMessage { get; set; }

        public string Name { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }

        public int? CitizenshipId { get; set; }
        public Citizenship Citizenship { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public int? CountryResidenceId { get; set; }
        public Country CountryResidence { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTimeOffset? DocumentDateIssued { get; set; }
        public DateTimeOffset? DocumentDateExpire { get; set; }
        public string VerificationCode { get; set; }

        /* Document images ids */
        public string ProofOfAddress { get; set; }
        public int? TypeProofOfAddressId { get; set; }
        public TypeProofOfAddress TypeProofOfAddress { get; set; }
        public int? TypeIdentityCardId { get; set; }
        public TypeIdentityCard TypeIdentityCard { get; set; }
        public string IdentityCard { get; set; }
        public string IdentityCardBackside { get; set; }
        public string PhotoWithDocument { get; set; }
        public string UserAuthenticationVideo { get; set; }

        public List<VerificationCard> VerificationCards { get; set; }

        /// <summary> Verification location </summary>
        /// <returns> if true - it means from the exchanger, by default false means the exchange </returns>
        public bool ApplicationFromExchanger { get; set; }

        public DateTimeOffset? DateCreate { get; set; }
        public DateTimeOffset? DateVerification { get; set; }
        public DateTimeOffset? DateFilled { get; set; }
    }

    public enum StatusVerificationUser
    {
        /// <summary>Not fully filled yet</summary>
        OnFilling = 0,

        /// <summary>Being processed</summary>
        OnVerification = 1,

        Failed = 2,
        Success = 3
    }

    public enum UserVerificationStage
    {
        NoVerification = 0,
        BasicVerification = 10,
        AdvancedVerification = 20,
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_EN { get; set; }
    }

    public class Citizenship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_EN { get; set; }
    }
}
