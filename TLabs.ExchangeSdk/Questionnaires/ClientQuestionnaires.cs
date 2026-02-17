using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Questionnaires;

public class ClientQuestionnaires
{
    private const string BaseUrl = "userprofiles/questionnaires";

    public async Task<Questionnaire> GetQuestionnaire(QuestionnaireType type, int? version)
    {
        var result = await BaseUrl.InternalApi()
            .SetQueryParam(nameof(type), type.ToString())
            .SetQueryParam(nameof(version), version)
            .GetJsonAsync<Questionnaire>();

        return result;
    }

    public async Task<QuestionnaireCompletionStatus> GetQuestionnaireCompletion(string userId, QuestionnaireType type, int? version)
    {
        var result = await $"{BaseUrl}/completion".InternalApi()
            .SetQueryParam(nameof(userId), userId)
            .SetQueryParam(nameof(type), type.ToString())
            .SetQueryParam(nameof(version), version)
            .GetJsonAsync<QuestionnaireCompletionStatus>();

        return result;
    }

    public async Task<IFlurlResponse> CreateQuestionnaireAnswer(QuestionnaireAnswerDto answer)
    {
        var result = await $"{BaseUrl}/answer".InternalApi()
            .SetQueryParam(nameof(answer.UserId), answer.UserId)
            .PostJsonAsync(answer);

        return result;
    }
}
