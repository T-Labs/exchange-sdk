namespace TLabs.ExchangeSdk.Futures;

public enum FuturesTransferState
{
    /// <summary>Проводка в депозитории ещё не подтверждена; перевод дожимает фоновый воркер</summary>
    Pending = 10,

    /// <summary>Проводка в депозитории есть, внутренний баланс приведён в соответствие</summary>
    Completed = 20,

    /// <summary>Депозиторий отказал; для вывода средства возвращены на фьючерсный счёт</summary>
    Failed = 30,
}
