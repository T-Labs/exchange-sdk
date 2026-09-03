using System;
using System.Collections.Generic;

using TLabs.ExchangeSdk.DevelopersSalary.Enums;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Developer receiving payouts from the developers salary wallet to external crypto addresses.</summary>
    public class DeveloperDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public DeveloperStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public List<DeveloperAddressDto> Addresses { get; set; }

        public override string ToString() =>
            $"{nameof(DeveloperDto)}(Id:{Id}, {Name}, {Status})";
    }
}
