using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.P2P;

public class UserBlock
{
    public string UserId { get; set; }
    public string BlockedUserId { get; set; }
    public string Comment { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }

    public DateTimeOffset BlockingDate { get; set; }
}
