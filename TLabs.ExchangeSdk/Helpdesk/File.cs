using System;

namespace TLabs.ExchangeSdk.Helpdesk;

public class File
{
    public Guid Id { get; set; }
    public string Extension { get; set; }
    public byte[] Data { get; set; }
    public Guid? MessageId { get; set; }
    public HelpdeskTicketMessage Message { get; set; }
}
