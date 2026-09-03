using System;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Create or update a developer. Empty <see cref="Id"/> creates a new one.</summary>
    public class SaveDeveloperDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public override string ToString() =>
            $"{nameof(SaveDeveloperDto)}(Id:{Id}, {Name})";
    }
}
