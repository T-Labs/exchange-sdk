using System;
using System.Collections.Generic;
using TLabs.ExchangeSdk.Files;

namespace TLabs.ExchangeSdk.CashHandover;

public class CashHandoverClient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string From { get; set; }
    public string Comment { get; set; }
    public string PrimaryContact { get; set; }
    public string Email { get; set; }
    public List<CashHandoverClientDocument> Documents { get; set; } = new();
    public Guid? ContractId { get; set; }
    public CashHandoverClientContract Contract { get; set; }
}

public class CashHandoverClientDocument
{
    public Guid Id { get; set; }
    public int DocumentTypeId { get; set; }
    public CashHandoverClientDocumentType DocumentType { get; set; }
    public File File { get; set; }
}

public class CashHandoverClientDocumentType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CashHandoverClientContract
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<File> Files { get; set; } = new();
}
