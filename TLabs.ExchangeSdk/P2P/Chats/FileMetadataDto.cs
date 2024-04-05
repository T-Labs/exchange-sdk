using Newtonsoft.Json;
using TLabs.ExchangeSdk.P2P.Deals;

namespace TLabs.ExchangeSdk.P2P.Chats;

public class FileMetadataDto
{
    public string FileName { get; set; }
    public string Extension { get; set; }

    [JsonIgnore]
    public Deal Deal { get; set; }
}
