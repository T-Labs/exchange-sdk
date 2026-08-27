using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.DevelopersSalary.Models
{
    /// <summary>Developer receiving payouts from the developers salary wallet to external crypto addresses.</summary>
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }

        public bool IsArchived { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public List<DeveloperAddress> Addresses { get; set; }

        public override string ToString() =>
            $"{nameof(Developer)}(Id:{Id}, {Name}, archived:{IsArchived})";
    }
}
