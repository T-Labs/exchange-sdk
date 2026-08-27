namespace TLabs.ExchangeSdk.Futures;

// Значения — период в секундах: wire-контракт Stock.Futures
public enum CandleTimePeriod
{
    OneMinute = 60,
    ThreeMinutes = 60 * 3,
    FiveMinutes = 60 * 5,
    FifteenMinutes = 60 * 15,
    ThirtyMinutes = 60 * 30,
    OneHour = 60 * 60,
    FourHour = 60 * 60 * 4,
    EightHour = 60 * 60 * 8,
    OneDay = 60 * 60 * 24,
    OneWeek = 60 * 60 * 24 * 7,
    OneMonth = 60 * 60 * 24 * 30
}
