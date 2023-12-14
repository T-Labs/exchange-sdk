using System.ComponentModel;

namespace TLabs.ExchangeSdk.Bwp;

public class NotificationModel
{
    public NotificationType NotificationType { get; set; }
    public string Message { get; set; }

    public NotificationModel()
    {
    }

    public NotificationModel(NotificationType notificationType)
    {
        NotificationType = notificationType;
    }
}

public enum NotificationType
{
    [Description("Поступил новый запрос на обмен!")]
    NewInvoice,
    [Description("Список запросов на обмен обновлен!")]
    UpdateInvoice,
    [Description("Поступила новая сделка!")]
    NewDeal,
    [Description("Список сделок обновлен!")]
    UpdateDeal,
}
