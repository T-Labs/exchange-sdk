namespace TLabs.ExchangeSdk.Futures;

public enum TransactionHistoryType
{
    /// <summary>Зачисление на фьючерсный счёт переводом со спота</summary>
    TransferIn = 1,

    /// <summary>Списание с фьючерсного счёта переводом на спот</summary>
    TransferOut = 2,

    /// <summary>Реализованный финансовый результат по закрытой позиции</summary>
    PNL = 3,

    /// <summary>Торговая комиссия по сделке</summary>
    TradingFee = 4,

    /// <summary>Фандинг по открытой позиции</summary>
    Funding = 5,

    /// <summary>Блокировка доли прибыли копирующего счёта на период расчёта</summary>
    CopyTradingProfitBlock = 6,

    /// <summary>Выплата доли прибыли мастеру копи-трейдинга</summary>
    CopyTradingProfit = 7,

    /// <summary>Разблокировка ранее заблокированной доли прибыли</summary>
    CopyTradingProfitUnBlock = 8,

    /// <summary>
    /// Сторнирующая проводка: депозиторий отказал по переводу, средства возвращены на фьючерсный
    /// счёт, сам перевод переведён в состояние Failed. Не пользовательская операция — компенсация,
    /// парная к TransferOut с тем же transferId.
    /// </summary>
    TransferCompensation = 9,

    /// <summary>
    /// Списание отрицательного капитала при ликвидации: цена прошла мимо расчётной цены
    /// ликвидации, убыток превысил баланс, разницу оплатила площадка. Сумма отрицательная.
    /// </summary>
    LiquidationWriteOff = 10,
}
