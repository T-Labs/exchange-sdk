using Newtonsoft.Json;
using System;
using TLabs.ExchangeSdk.P2P.Deals;

namespace TLabs.ExchangeSdk.P2P.Chats;

public class ChatFileMetadataDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string Extension { get; set; }
    public long FileSize { get; set; }

    [JsonIgnore]
    public Deal Deal { get; set; }
}
