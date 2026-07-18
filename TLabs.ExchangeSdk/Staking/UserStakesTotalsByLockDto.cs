namespace TLabs.ExchangeSdk.Staking;

public class UserStakesTotalsByLockDto
{
    public decimal AnnualAmount { get; set; }

    public decimal MonthlyAmount { get; set; }

    public decimal OtherAmount { get; set; }

    public bool HasAnnualStake => AnnualAmount > 0;
}
