using System;

namespace TLabs.ExchangeSdk.P2P;

public class DealCommentDto
{
    public Guid DealId { get; set; }

    public string FromUserId { get; set; }
    public bool IsPositive { get; set; }
    public string Comment { get; set; }
}
