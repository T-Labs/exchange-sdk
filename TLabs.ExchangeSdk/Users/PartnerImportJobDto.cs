using System;

namespace TLabs.ExchangeSdk.Users;

public class PartnerImportJobDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; }

    public PartnerImportJobStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? CompletedAt { get; set; }

    public int TotalRows { get; set; }

    public int PendingRows { get; set; }

    public int CompletedRows { get; set; }

    public int SkippedExistingRows { get; set; }

    public int FailedRows { get; set; }

    public int ProcessingRows { get; set; }
}
