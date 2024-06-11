using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.News.Dtos;

namespace TLabs.ExchangeSdk.News;

public class ClientNews
{
    public Task<JsonResult> Get()
    {
        var result = $"news/healthcheck".InternalApi()
            .GetJsonAsync<JsonResult>();
        return result;
    }

    #region news

    public async Task<List<NewsItem>> GetAll(Language? language)
    {
        var result = await $"news".InternalApi()
            .SetQueryParam(nameof(language), language)
            .GetJsonAsync<List<NewsItem>>();
        return result;
    }

    public async Task<NewsItemViewModel> GetId(long id)
    {
        var result = await $"news/{id}".InternalApi()
            .GetJsonAsync<NewsItemViewModel>();
        return result;
    }

    public async Task<long> Create(NewsDto newsItem)
    {
        var result = await $"news".InternalApi()
            .PostJsonAsync<long>(newsItem);
        return result;
    }

    public async Task<long> Update(NewsDto newsDto)
    {
        var result = await $"news".InternalApi()
            .PutJsonAsync<long>(newsDto);
        return result;
    }

    public async Task<long> Delete(long id)
    {
        var result = await $"news/{id}".InternalApi()
            .DeleteJsonAsync<long>(null);
        return result;
    }

    #endregion news

    #region comments

    public async Task<NewsComment> GetComment(long id)
    {
        var result = await $"news/news-comments/{id}".InternalApi().GetJsonAsync<NewsComment>();
        return result;
    }

    public async Task<List<NewsComment>> GetComments()
    {
        var result = await $"news/news-comments".InternalApi().GetJsonAsync<List<NewsComment>>();
        return result;
    }

    public async Task<NewsComment> CreateNewsComment(NewsCommentDto commentDto)
    {
        var result = await $"news/news-comments".InternalApi().PostJsonAsync<NewsComment>(commentDto);
        return result;
    }

    public async Task<NewsComment> DeleteComment(long id)
    {
        var result = await $"news/news-comments/{id}".InternalApi().PostJsonAsync<NewsComment>(null);
        return result;
    }

    public async Task<List<CommentLike>> UpdateCommentLike(UpdateLikeDto updateLikeDto)
    {
        var result = await $"news/news-comments".InternalApi().PostJsonAsync<List<CommentLike>>(updateLikeDto);
        return result;
    }

    #endregion comments

    #region faq

    public async Task<List<FaqQuestion>> GetFaqQuestions(Language? language)
    {
        var result = await $"news/faq".InternalApi()
            .SetQueryParam(nameof(language), language)
            .GetJsonAsync<List<FaqQuestion>>();
        return result;
    }

    public async Task<FaqQuestion> GetFaqQuestion(int id)
    {
        var result = await $"news/faq/{id}".InternalApi().GetJsonAsync<FaqQuestion>();
        return result;
    }

    public async Task<IFlurlResponse> PutFaqQuestion(int id, FaqQuestion faqQuestion)
    {
        var result = await $"news/faq".InternalApi().PutJsonAsync(faqQuestion);
        return result;
    }

    public async Task<IFlurlResponse> PostFaqQuestion(FaqQuestion faqQuestion)
    {
        var result = await $"news/faq".InternalApi().PostJsonAsync(faqQuestion);
        return result;
    }

    public async Task<IFlurlResponse> DeleteFaqQuestion(int id)
    {
        var result = await $"news/faq/{id}".InternalApi().DeleteAsync();
        return result;
    }

    #endregion faq

    #region image

    public async Task<Image> GetImage(string id)
    {
        var result = await $"news/image/{id}".InternalApi().GetJsonAsync<Image>();
        return result;
    }

    public async Task<string> UploadImage(UploadImage model)
    {
        var result = await $"news/image".InternalApi().PutJsonAsync<string>(model);
        return result;
    }

    #endregion image

    #region signalChannels

    public async Task<List<SignalChannel>> GetSignalChannels()
    {
        var result = await $"news/signals/channels".InternalApi().GetJsonAsync<List<SignalChannel>>();
        return result;
    }

    public async Task<SignalChannel> GetSignalChannel(int id)
    {
        var result = await $"news/signals/channels/{id}".InternalApi().GetJsonAsync<SignalChannel>();
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IFlurlResponse> PutSignalChannel(int id, SignalChannel signalChannel)
    {
        var result = await $"news/signals/channels/{id}".InternalApi().PutJsonAsync(signalChannel);
        return result;
    }

    [HttpPost]
    public async Task<IFlurlResponse> PostSignalChannel(SignalChannel signalChannel)
    {
        var result = await $"news/signals/channels".InternalApi().PostJsonAsync(signalChannel);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IFlurlResponse> DeleteSignalChannel(int id)
    {
        var result = await $"news/signals/channels/{id}".InternalApi().DeleteAsync();
        return result;
    }

    #endregion signalChannels

    #region signals

    public async Task<List<Signal>> GetSignals(Language? language, int? channelId = null)
    {
        var result = await $"news/signals".InternalApi()
            .SetQueryParam(nameof(language), language)
            .SetQueryParam(nameof(channelId), channelId)
            .GetJsonAsync<List<Signal>>();
        return result;
    }

    public async Task<Signal> GetSignal([FromRoute] int id)
    {
        var result = await $"news/signals/{id}".InternalApi().GetJsonAsync<Signal>();
        return result;
    }

    public async Task<IFlurlResponse> PutSignal(int id, Signal signal)
    {
        var result = await $"news/signals/{id}".InternalApi().PutJsonAsync(signal);
        return result;
    }

    public async Task<IFlurlResponse> PostSignal(Signal signal)
    {
        var result = await $"news/signals".InternalApi().PostJsonAsync(signal);
        return result;
    }

    public async Task<IFlurlResponse> DeleteSignal(int id)
    {
        var result = await $"news/signals/{id}".InternalApi().DeleteAsync();
        return result;
    }

    #endregion signals
}
