namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardAdminStatsDto
{
    public int Total { get; set; }

    public int Requested { get; set; }
    public int Active { get; set; }
    public int Blocked { get; set; }
    public int Closed { get; set; }
    public int Failed { get; set; }
    public int AwaitingShipment { get; set; }

    public int Virtual { get; set; }
    public int Physical { get; set; }

    public int VirtualActive { get; set; }
    public int PhysicalActive { get; set; }

    public int VirtualBlocked { get; set; }
    public int PhysicalBlocked { get; set; }
}
