using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.P2P.Chats;
using TLabs.ExchangeSdk.P2P.Deals;
using TLabs.ExchangeSdk.P2P.Users;

namespace TLabs.ExchangeSdk.P2P;

public class ClientP2P
{
    public async Task<List<Order>> GetOrders(string exchangeCurrencyCode = null, string paymentCurrencyCode = null,
        int? paymentSystemId = null,
        bool? isBuyingOnExchange = null,
        string userId = null,
        OrderStatus? status = null,
        DateTimeOffset? dateFrom = null, DateTimeOffset? dateTo = null,
        decimal? dealCryptoAmount = null, decimal? dealFiatAmount = null, string dealUserId = null)
    {
        var result = await $"p2p/orders".InternalApi()
            .SetQueryParam(nameof(exchangeCurrencyCode), exchangeCurrencyCode)
            .SetQueryParam(nameof(paymentCurrencyCode), paymentCurrencyCode)
            .SetQueryParam(nameof(paymentSystemId), paymentSystemId)
            .SetQueryParam(nameof(isBuyingOnExchange), isBuyingOnExchange)
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(status), status)
            .SetQueryParam(nameof(dateFrom), dateFrom?.ToString("o"))
            .SetQueryParam(nameof(dateTo), dateTo?.ToString("o"))
            .SetQueryParam(nameof(dealCryptoAmount), dealCryptoAmount)
            .SetQueryParam(nameof(dealFiatAmount), dealFiatAmount)
            .SetQueryParam(nameof(dealUserId), dealUserId)
            .GetJsonAsync<List<Order>>();
        return result;
    }

    public async Task<Order> GetOrder(Guid id)
    {
        return await $"p2p/orders/{id}".InternalApi()
            .GetJsonAsync<Order>();
    }

    public async Task<Order> CreateOrder(OrderCreateDto orderDto)
    {
        return await $"p2p/orders".InternalApi()
            .PostJsonAsync<Order>(orderDto);
    }

    public async Task<Order> CloneOrder(Guid id, [FromBody] OrderCreateDto orderDto)
    {
        return await $"p2p/orders/{id}/clone".InternalApi()
            .PostJsonAsync<Order>(orderDto);
    }

    public async Task<IFlurlResponse> CancelOrder(Guid id, string orderUserId)
    {
        return await $"p2p/orders/{id}/cancel".InternalApi()
            .SetQueryParam(nameof(orderUserId), orderUserId)
            .PostAsync();
    }

    public async Task<List<Deal>> GetDeals(string dealUserId = null, string orderUserId = null,
        [FromQuery] List<DealStatus> statuses = null)
    {
        return await $"p2p/deals".InternalApi()
            .SetQueryParam(nameof(dealUserId), dealUserId)
            .SetQueryParam(nameof(orderUserId), orderUserId)
            .SetQueryParam(nameof(statuses), statuses)
            .GetJsonAsync<List<Deal>>();
    }

    public async Task<Deal> GetDeal(Guid id)
    {
        return await $"p2p/deals/{id}".InternalApi()
            .GetJsonAsync<Deal>();
    }

    public async Task<Deal> CreateDeal(DealCreateDto dealDto)
    {
        return await $"p2p/deals".InternalApi()
            .PostJsonAsync<Deal>(dealDto);
    }

    public async Task<Deal> UpdateDealPaymentStatus(Guid id, DealStatus newDealStatus, string userId)
    {
        return await $"p2p/deals/{id}/payment-status".InternalApi()
            .SetQueryParam(nameof(newDealStatus), newDealStatus)
            .SetQueryParam(nameof(userId), userId)
            .PutJsonAsync<Deal>(null);
    }

    public async Task<Deal> OpenDealAppeal(Guid id, string userId)
    {
        return await $"p2p/deals/{id}/appeal".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PostJsonAsync<Deal>(null);
    }

    public async Task<Deal> CancelDeal(Guid id, string userId)
    {
        return await $"p2p/deals/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .DeleteJsonAsync<Deal>(null);
    }

    public async Task<List<Requisite>> GetActiveRequisites(string userId = null)
    {
        return await $"p2p/requisites".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<Requisite>>();
    }

    public async Task<Requisite> GetActiveRequisite(Guid id)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .GetJsonAsync<Requisite>();
    }

    public async Task<IFlurlResponse> CreateRequisite(RequisiteDto requisiteDto)
    {
        return await $"p2p/requisites".InternalApi()
            .PostJsonAsync(requisiteDto);
    }

    public async Task<IFlurlResponse> UpdateRequisite(Guid id, RequisiteDto requisiteDto)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .PutJsonAsync(requisiteDto);
    }

    public async Task<IFlurlResponse> DeleteRequisite(Guid id)
    {
        return await $"p2p/requisites/{id}".InternalApi()
            .DeleteAsync();
    }

    public async Task<PaymentMethod> GetPaymentMethodByCurrencyCode(string exchangeCurrencyCode)
    {
        return await $"p2p/payment-methods".InternalApi()
            .SetQueryParam(nameof(exchangeCurrencyCode), exchangeCurrencyCode)
            .GetJsonAsync<PaymentMethod>();
    }

    public async Task<List<PaymentCurrency>> GetPaymentCurrencies([FromQuery] int? paymentSystemId = null)
    {
        return await $"p2p/payment-currencies".InternalApi()
            .SetQueryParam(nameof(paymentSystemId), paymentSystemId)
            .GetJsonAsync<List<PaymentCurrency>>();
    }

    public async Task<List<PaymentSystem>> GetPaymentSystems(string currencyCode = null)
    {
        return await $"p2p/payment-systems".InternalApi()
            .SetQueryParam(nameof(currencyCode), currencyCode)
            .GetJsonAsync<List<PaymentSystem>>();
    }

    public async Task<UserInfoDto> GetUserOrdersInfo(string userId)
    {
        return await $"p2p/users/{userId}/info".InternalApi()
            .GetJsonAsync<UserInfoDto>();
    }

    public async Task<UserOrderLimitsDto> GetUserOrderOpeningLimits(string userId, bool isBuyingOnExchange,
        string exchangeCurrencyCode, string paymentCurrencyCode, decimal price, List<Guid> requisiteIds = null)
    {
        return await $"p2p/users/{userId}/trading-limits/order".InternalApi()
            .SetQueryParam(nameof(isBuyingOnExchange), isBuyingOnExchange)
            .SetQueryParam(nameof(exchangeCurrencyCode), exchangeCurrencyCode)
            .SetQueryParam(nameof(paymentCurrencyCode), paymentCurrencyCode)
            .SetQueryParam(nameof(price), price)
            .SetQueryParam(nameof(requisiteIds), requisiteIds)
            .GetJsonAsync<UserOrderLimitsDto>();
    }

    public async Task<UserDealLimitsDto> GetUserDealOpeningLimits(string userId)
    {
        return await $"p2p/users/{userId}/trading-limits/deal".InternalApi()
            .GetJsonAsync<UserDealLimitsDto>();
    }

    public async Task<List<DealComment>> GetDealComments(Guid? dealId = null, string fromUserId = null,
        string toUserId = null)
    {
        return await $"p2p/deal-comments/".InternalApi()
            .SetQueryParam(nameof(dealId), dealId)
            .SetQueryParam(nameof(fromUserId), fromUserId)
            .SetQueryParam(nameof(toUserId), toUserId)
            .GetJsonAsync<List<DealComment>>();
    }

    public async Task<DealComment> CreateDealComment(DealCommentDto dealCommentDto)
    {
        return await $"p2p/deal-comments".InternalApi()
            .PostJsonAsync<DealComment>(dealCommentDto);
    }

    public async Task<DealComment> UpdateDealComment([FromBody] DealCommentDto dealCommentDto)
    {
        return await $"p2p/deal-comments".InternalApi()
            .PutJsonAsync<DealComment>(dealCommentDto);
    }

    public async Task<IFlurlResponse> DeleteDealComment(Guid dealCommentId, string fromUserId)
    {
        return await $"p2p/deal-comments/{dealCommentId}".InternalApi()
            .SetQueryParam(nameof(fromUserId), fromUserId)
            .DeleteAsync();
    }

    public async Task<List<UserBlock>> GetUserBlockList(string userId = null, string blockedUserId = null)
    {
        return await $"p2p/user-blocks".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(blockedUserId), blockedUserId)
            .GetJsonAsync<List<UserBlock>>();
    }

    public async Task<UserBlock> BlockUser([FromBody] UserBlockCreateDto userBlockCreateDto)
    {
        return await $"p2p/user-blocks".InternalApi()
            .PostJsonAsync<UserBlock>(userBlockCreateDto);
    }

    public async Task<IFlurlResponse> DeleteBlockUser(string userId, string unblockedUserId)
    {
        return await $"p2p/user-blocks/{userId}".InternalApi()
            .SetQueryParam(nameof(unblockedUserId), unblockedUserId)
            .DeleteAsync();
    }

    public async Task<List<ChatMessage>> GetMessages(Guid dealId, string userId)
    {
        return await $"p2p/chats".InternalApi()
            .SetQueryParam(nameof(dealId), dealId)
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<ChatMessage>>();
    }

    public async Task<ChatMessage> GetMessage(Guid id, string userId)
    {
        return await $"p2p/chats/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChatMessage>();
    }

    public async Task<IFlurlResponse> AddMessage(ChatMessageCreateDto dto)
    {
        return await $"p2p/chats".InternalApi()
            .PostJsonAsync(dto);
    }

    public async Task<IFlurlResponse> SetMessagesWasRead(List<Guid> ids, string userId)
    {
        return await $"p2p/chats/reads".InternalApi()
            .SetQueryParam(nameof(ids), ids)
            .SetQueryParam(nameof(userId), userId)
            .PutAsync();
    }

    public async Task<IFlurlResponse> SetMessageWasRead(Guid id, string userId)
    {
        return await $"p2p/chats/{id}/read".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .PutAsync();
    }

    public async Task<IFlurlResponse> UploadFile(MultipartFormDataContent data)
    {
        return await $"p2p/chats/upload-file".InternalApi()
            .PostAsync(data);
    }

    public async Task<ChatFile> GetChatFile(Guid id, string userId)
    {
        return await $"p2p/chats/files/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChatFile>();
    }

    public async Task<ChatFileMetadataDto> GetChatFileMetadata(Guid id, string userId)
    {
        return await $"p2p/chats/files/{id}/metadata".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChatFileMetadataDto>();
    }

    public async Task<ChatUsersInfo> GetChatUsersInfo(Guid dealId, string userId)
    {
        return await $"p2p/chats/users-info".InternalApi()
            .SetQueryParam(nameof(dealId), dealId)
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<ChatUsersInfo>();
    }

    public async Task<List<CurrencyPairTradingVolume>> GetTradeVolume([FromQuery] DateTimeOffset? dateFrom,
        [FromQuery] DateTimeOffset? dateTo)
    {
        return await $"p2p/statistics/trade-volumes".InternalApi()
            .SetQueryParam(nameof(dateFrom), dateFrom?.ToString("o"))
            .SetQueryParam(nameof(dateTo), dateTo?.ToString("o"))
            .GetJsonAsync<List<CurrencyPairTradingVolume>>();
    }

    public async Task<List<DealAppeal>> GetDealAppeals(Guid dealId, string userId)
    {
        return await $"p2p/deals/{dealId}/appeals".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<List<DealAppeal>>();
    }

    public async Task<DealAppeal> GetDealAppeal(Guid id, string userId)
    {
        return await $"p2p/deal-appeals/{id}".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<DealAppeal>();
    }

    public async Task<List<DealAppeal>> GetAllDealAppeals(string userId = null, string dealUserId = null,
        Guid? dealId = null, long? dealDisplayId = null, AppealStatus? appealStatus = null,
        string ExchangeCurrencyCode = null, string PaymentCurrencyCode = null)
    {
        return await $"p2p/deal-appeals/all".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(dealUserId), dealUserId)
            .SetQueryParam(nameof(dealId), dealId)
            .SetQueryParam(nameof(dealDisplayId), dealDisplayId)
            .SetQueryParam(nameof(appealStatus), appealStatus)
            .SetQueryParam(nameof(ExchangeCurrencyCode), ExchangeCurrencyCode)
            .SetQueryParam(nameof(PaymentCurrencyCode), PaymentCurrencyCode)
            .GetJsonAsync<List<DealAppeal>>();
    }

    public async Task<IFlurlResponse> OpenDealAppeal(DealAppealCreateDto dealAppealCreateDto)
    {
        return await $"p2p/deal-appeals".InternalApi()
            .PostJsonAsync(dealAppealCreateDto);
    }

    public async Task<IFlurlResponse> FinishAppeal(Guid dealId, string userId, AppealStatus appealStatus)
    {
        return await $"p2p/deals/{dealId}/appeal-status".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(appealStatus), appealStatus)
            .PutAsync();
    }

    public async Task<DealCancelDispute> GetDealCancelDisputeByDealId(Guid dealId, string userId)
    {
        return await $"p2p/deals/{dealId}/cancel-dispute".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .GetJsonAsync<DealCancelDispute>();
    }

    public async Task<List<DealCancelDispute>> GetDealCancelDisputes(string creatorUserId = null,
        string respondentUserId = null, DealCancelDisputeStatus? dealDisputeStatus = null)
    {
        return await $"p2p/deal-cancel-disputes".InternalApi()
            .SetQueryParam(nameof(creatorUserId), creatorUserId)
            .SetQueryParam(nameof(respondentUserId), respondentUserId)
            .SetQueryParam(nameof(dealDisputeStatus), dealDisputeStatus)
            .GetJsonAsync<List<DealCancelDispute>>();
    }

    public async Task<IFlurlResponse> OpenDealCancelDispute(DealCancelDisputeCreateDto dealCancelDisputeCreateDto)
    {
        return await $"p2p/deal-cancel-disputes".InternalApi()
            .PostJsonAsync(dealCancelDisputeCreateDto);
    }

    public async Task<IFlurlResponse> UpdateDealCancelDisputeStatus(Guid dealId, string userId,
        DealCancelDisputeStatus dealCancelDisputeStatus)
    {
        return await $"p2p/deals/{dealId}/cancel-dispute/status".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(dealCancelDisputeStatus), dealCancelDisputeStatus)
            .PutJsonAsync(null);
    }
}
