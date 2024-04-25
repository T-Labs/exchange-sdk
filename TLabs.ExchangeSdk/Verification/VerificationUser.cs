using System;

namespace TLabs.ExchangeSdk.Verification
{
    public class VerificationUser
    {
        public string Id { get; set; }

        /// <summary>
        /// Этап верификации
        /// </summary>
        public UserVerificationStage VerificationStage { get; set; }

        /// <summary>
        /// Статус документа
        /// </summary>
        public StatusVerificationUser Status { get; set; } = StatusVerificationUser.Success;

        /// <summary>
        /// Комментарий администратора при изменении статуса анкеты
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public int? CitizenshipId { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public Citizenship Citizenship { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTimeOffset? DateOfBirth { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Skype
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Страна проживания Id
        /// </summary>
        public int? CountryResidenceId { get; set; }

        /// <summary>
        /// Страна проживания
        /// </summary>
        public Country CountryResidence { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostCode { get; set; }

        public string DocumentNumber { get; set; }

        public DateTimeOffset? DocumentDateIssued { get; set; }

        public DateTimeOffset? DocumentDateExpire { get; set; }

        /* Document images ids */

        /// <summary>
        /// Подтверждения адреса имя файла
        /// </summary>
        public string ProofOfAddress { get; set; }

        /// <summary>
        /// Тип потверждения  адреса
        /// </summary>
        public int? TypeProofOfAddressId { get; set; }

        /// <summary>
        /// Удостоверение личности (имя файла)
        /// </summary>
        public string IdentityCard { get; set; }

        /// <summary>
        /// Тип удостоверение личности
        /// </summary>
        public int? TypeIdentityCardId { get; set; }

        /// <summary>
        /// Фото человека с документом (имя файла)
        /// </summary>
        public string PhotoWithDocument { get; set; }

        /// <summary>
        /// Место верификации
        /// </summary>
        /// <returns>
        /// если true - значит с обменника, по дефолту false значит биржа
        /// </returns>
        public bool ApplicationFromExchanger { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset? DateCreate { get; set; }

        /// <summary>
        /// Дата верификации
        /// </summary>
        public DateTimeOffset? DateVerification { get; set; }
    }

    public enum StatusVerificationUser
    {
        /// <summary>Not fully filled yet</summary>
        OnFilling = 0,

        /// <summary>Being processed</summary>
        OnVerification = 1,

        /// <summary>Failed</summary>
        Failed = 2,

        /// <summary>Confirmed</summary>
        Success = 3
    }

    public enum UserVerificationStage
    {
        NoVerification = 0,
        BasicVerification = 10,
        AdvancedVerification = 20,
    }

    /// <summary>Country</summary>
    public class Country
    {
        public int Id { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>Name in English</summary>
        public string Name_EN { get; set; }
    }

    /// <summary>Citizenship</summary>
    public class Citizenship
    {
        public int Id { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>Name in English</summary>
        public string Name_EN { get; set; }
    }
}
