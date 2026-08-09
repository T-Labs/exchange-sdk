using System;

namespace TLabs.ExchangeSdk.Staking
{
    /// <summary>Create stake for user, funded by internal transfer from admin's balance</summary>
    public class CreateUserStakeByAdminDto
    {
        /// <summary>Admin whose balance funds the stake</summary>
        public string AdminUserId { get; set; }

        /// <summary>User that receives the stake</summary>
        public string UserId { get; set; }

        public Guid StakingSettingId { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// Idempotency key: caller keeps it unchanged while retrying the same operation
        /// (lost response, timeout) and generates a new one for a different operation.
        /// Brokerage uses it as the ledger ActionId and rejects a repeated request.
        /// </summary>
        public Guid RequestId { get; set; }

        public override string ToString() => $"{nameof(CreateUserStakeByAdminDto)}({Amount}, " +
            $"admin:{AdminUserId} -> user:{UserId}, settingId:{StakingSettingId}, " +
            $"requestId:{RequestId})";
    }
}
