using System;

namespace TLabs.ExchangeSdk.Files;

public class File
{
    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    public string Extension { get; set; }
    public FilePurpose Purpose { get; set; }
}

public enum FilePurpose
{
    Image = 10,
    CashHandoverClientContract = 20,
    CashHandoverClientDocument = 30,
}
