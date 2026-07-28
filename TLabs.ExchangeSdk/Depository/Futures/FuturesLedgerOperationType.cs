namespace TLabs.ExchangeSdk.Depository.Futures
{
    public enum FuturesLedgerOperationType
    {
        TransferFromSpot = 1,
        TransferToSpot = 2,
        TransferBetweenAccounts = 3,
        Credit = 4,
        Debit = 5,
        BlockCopyTrading = 6,
        ReleaseCopyTrading = 7,
        PayCopyTrading = 8,
        ResetBalance = 9
    }
}
