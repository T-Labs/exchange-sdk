using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Helpdesk;

public class TelegramAttachmentDto
{
    public string TelegramFileId { get; set; }
    public string TelegramFileUniqueId { get; set; }
}

public class TelegramTicketCreateDto
{
    public string ExternalRequestId { get; set; }
    public long TelegramUserId { get; set; }
    public string Source { get; set; }
    public string Text { get; set; }
    public string Header { get; set; }
    public List<TelegramAttachmentDto> Attachments { get; set; } = new List<TelegramAttachmentDto>();
}

public class TelegramTicketMessageCreateDto
{
    public string Text { get; set; }
    public List<TelegramAttachmentDto> Attachments { get; set; } = new List<TelegramAttachmentDto>();
}

public class TelegramTicketResponseDto
{
    public Guid TicketId { get; set; }
    public string RequestId { get; set; }
    public int Number { get; set; }
    public long TelegramUserId { get; set; }
    public string ExternalRequestId { get; set; }
    public bool Created { get; set; }
}

public class SupportBotReplyDto
{
    public long TelegramUserId { get; set; }
    public string RequestId { get; set; }
    public string Text { get; set; }
}
