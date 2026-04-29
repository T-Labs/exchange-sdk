using System;

namespace TLabs.ExchangeSdk.Users
{
    public class AccountDeletionStateDto
    {
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
