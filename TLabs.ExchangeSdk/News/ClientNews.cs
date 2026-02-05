#nullable enable

using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.News.Dtos;

namespace TLabs.ExchangeSdk.News;

public class ClientNews
{
    private const string BaseUrl = "news";

    public async Task<JsonResult> Healthcheck()
    {
        var result = await $"news/healthcheck".InternalApi()
            .GetJsonAsync<JsonResult>();
        return result;
    }

    #region news

    public async Task<List<NewsItemViewModel>> GetNewsViewModels(Language? language = null,
        string currencyListingCode = null)
    {
        var result = await $"{BaseUrl}/news".InternalApi()
            .SetQueryParam(nameof(language), language)
            .SetQueryParam(nameof(currencyListingCode), currencyListingCode)
            .GetJsonAsync<List<NewsItemViewModel>>();
        return result;
    }

    public async Task<NewsItemViewModel> GetNewsById(long id)
    {
        var result = await $"{BaseUrl}/news/{id}".InternalApi()
            .GetJsonAsync<NewsItemViewModel>();
        return result;
    }

    public async Task<long> CreateNews(NewsDto newsItem)
    {
        var result = await $"{BaseUrl}/news".InternalApi()
            .PostJsonAsync<long>(newsItem);
        return result;
    }

    public async Task<long> UpdateNews(NewsDto newsDto)
    {
        var result = await $"{BaseUrl}/news".InternalApi()
            .PutJsonAsync<long>(newsDto);
        return result;
    }

    public async Task<long> DeleteNews(long id)
    {
        var result = await $"{BaseUrl}/news/{id}".InternalApi()
            .DeleteJsonAsync<long>(null);
        return result;
    }

    #endregion news

    #region comments

    public async Task<NewsComment> GetComment(long id)
    {
        var result = await $"{BaseUrl}/news-comments/{id}".InternalApi()
            .GetJsonAsync<NewsComment>();
        return result;
    }

    public async Task<List<NewsComment>> GetComments(long? newsItemId = null)
    {
        var result = await $"{BaseUrl}/news-comments".InternalApi()
            .SetQueryParam(nameof(newsItemId), newsItemId)
            .GetJsonAsync<List<NewsComment>>();
        return result;
    }

    public async Task<NewsComment> CreateNewsComment(NewsCommentDto commentDto)
    {
        var result = await $"{BaseUrl}/news-comments".InternalApi()
            .PostJsonAsync<NewsComment>(commentDto);
        return result;
    }

    public async Task<IFlurlResponse> DeleteComment(long id)
    {
        var result = await $"{BaseUrl}/news-comments/{id}".InternalApi()
            .DeleteAsync();
        return result;
    }

    public async Task<List<CommentLike>> UpdateCommentLike(UpdateLikeDto updateLikeDto)
    {
        var result = await $"{BaseUrl}/news-comments/likes".InternalApi()
            .PutJsonAsync<List<CommentLike>>(updateLikeDto);
        return result;
    }

    #endregion comments

    #region faq

    public async Task<List<FaqQuestion>> GetFaqQuestions(Language? language = null)
    {
        var result = await $"{BaseUrl}/faq".InternalApi()
            .SetQueryParam(nameof(language), language)
            .GetJsonAsync<List<FaqQuestion>>();
        return result;
    }

    public async Task<FaqQuestion> GetFaqQuestion(int id)
    {
        var result = await $"{BaseUrl}/faq/{id}".InternalApi()
            .GetJsonAsync<FaqQuestion>();
        return result;
    }

    public async Task<IFlurlResponse> UpdateFaqQuestion(int id, FaqQuestion faqQuestion)
    {
        var result = await $"{BaseUrl}/faq/{id}".InternalApi()
            .PutJsonAsync(faqQuestion);
        return result;
    }

    public async Task<IFlurlResponse> CreateFaqQuestion(FaqQuestion faqQuestion)
    {
        var result = await $"{BaseUrl}/faq".InternalApi()
            .PostJsonAsync(faqQuestion);
        return result;
    }

    public async Task<IFlurlResponse> DeleteFaqQuestion(int id)
    {
        var result = await $"{BaseUrl}/faq/{id}".InternalApi()
            .DeleteAsync();
        return result;
    }

    #endregion faq

    #region image

    public async Task<byte[]?> GetImage(string id)
    {
        var result = await $"{BaseUrl}/image/{id}".InternalApi()
            .GetJsonAsync<byte[]>();
        return result;
    }

    public async Task<string> UploadImage(UploadImage model)
    {
        var result = await $"{BaseUrl}/image/upload".InternalApi()
            .PutJsonAsync<string>(model);
        return result;
    }

    public async Task<FileContentResult?> GetImageFileContentResult(string id)
    {
        var data = await GetImage(id);
        if (data == null)
            return null;

        var idData = id.Split('.', StringSplitOptions.RemoveEmptyEntries);
        var extension = "";
        if (idData.Length == 2) extension = idData[1];
        switch (extension)
        {
            case "gif":
                return new FileContentResult(data, "image/gif");

            case "png":
                return new FileContentResult(data, "image/png");

            case "webp":
                return new FileContentResult(data, "image/webp");

            default:
                return new FileContentResult(data, "image/jpeg");
        }
    }

    #endregion image

    #region signalChannels

    public async Task<List<SignalChannel>> GetSignalChannels()
    {
        var result = await $"{BaseUrl}/signals/channels".InternalApi()
            .GetJsonAsync<List<SignalChannel>>();
        return result;
    }

    public async Task<SignalChannel> GetSignalChannel(int id)
    {
        var result = await $"{BaseUrl}/signals/channels/{id}".InternalApi()
            .GetJsonAsync<SignalChannel>();
        return result;
    }

    public async Task<IFlurlResponse> UpdateSignalChannel(int id, SignalChannel signalChannel)
    {
        var result = await $"{BaseUrl}/signals/channels/{id}".InternalApi()
            .PutJsonAsync(signalChannel);
        return result;
    }

    public async Task<IFlurlResponse> CreateSignalChannel(SignalChannel signalChannel)
    {
        var result = await $"{BaseUrl}/signals/channels".InternalApi()
            .PostJsonAsync(signalChannel);
        return result;
    }

    public async Task<IFlurlResponse> DeleteSignalChannel(int id)
    {
        var result = await $"{BaseUrl}/signals/channels/{id}".InternalApi()
            .DeleteAsync();
        return result;
    }

    #endregion signalChannels

    #region signals

    public async Task<List<Signal>> GetSignals(Language? language = null, int? channelId = null)
    {
        var result = await $"{BaseUrl}/signals".InternalApi()
            .SetQueryParam(nameof(language), language)
            .SetQueryParam(nameof(channelId), channelId)
            .GetJsonAsync<List<Signal>>();
        return result;
    }

    public async Task<Signal> GetSignal(int id)
    {
        var result = await $"{BaseUrl}/signals/{id}".InternalApi()
            .GetJsonAsync<Signal>();
        return result;
    }

    public async Task<IFlurlResponse> UpdateSignal(int id, Signal signal)
    {
        var result = await $"{BaseUrl}/signals/{id}".InternalApi()
            .PutJsonAsync(signal);
        return result;
    }

    public async Task<IFlurlResponse> CreateSignal(Signal signal)
    {
        var result = await $"{BaseUrl}/signals".InternalApi()
            .PostJsonAsync(signal);
        return result;
    }

    public async Task<IFlurlResponse> DeleteSignal(int id)
    {
        var result = await $"{BaseUrl}/signals/{id}".InternalApi()
            .DeleteAsync();
        return result;
    }

    #endregion signals
}
