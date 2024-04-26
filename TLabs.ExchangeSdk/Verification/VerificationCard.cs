using System.ComponentModel.DataAnnotations;
using System;

namespace TLabs.ExchangeSdk.Verification;

public class VerificationCard
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public VerificationUser VerificationUser { get; set; }

    /// <summary>
    /// Статус документа
    /// </summary>
    public StatusVerificationCard Status { get; set; } = StatusVerificationCard.Success;

    /// <summary>
    /// Имя владельца
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 6 первых и 4 последних цифры карточки
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Месяц окончания
    /// </summary>
    public string ExpiryMonth { get; set; }

    /// <summary>
    /// Год окончания
    /// </summary>
    public string ExpiryYear { get; set; }

    /// <summary>
    /// Фото карты спереди
    /// </summary>
    public string PhotoCardFrontSide { get; set; }

    /// <summary>
    /// Фото карты сзади
    /// </summary>
    public string PhotoCardBackSide { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset? DateCreate { get; set; }

    /// <summary>
    /// Дата верификации
    /// </summary>
    public DateTimeOffset? DateVerification { get; set; }

    /// <summary>
    /// Комментарий администратора при изменении статуса анкеты
    /// </summary>
    public string StatusMessage { get; set; }
}

public enum StatusVerificationCard
{
    /// <summary>
    /// Еще не польностью заполнено
    /// </summary>
    OnFilling,

    /// <summary>
    /// На проверке
    /// </summary>
    OnVerification,

    /// <summary>
    /// Провалено
    /// </summary>
    Failed,

    /// <summary>
    /// Потверждено
    /// </summary>
    Success
}
