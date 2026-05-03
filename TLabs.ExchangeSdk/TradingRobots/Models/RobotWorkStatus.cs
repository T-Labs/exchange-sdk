namespace TLabs.ExchangeSdk.TradingRobots.Models;

public enum RobotWorkStatus
{
    Stopped = 0,
    StoppedNoNew = 1,
    Running = 2,
    StoppedCancelOpen = 3,
    Paused = 4,
}
