using System;

namespace TLabs.ExchangeSdk.Questionnaires;

public class QuestionnaireQuestionOption
{
    public Guid Id { get; set; }
    public Guid QuestionnaireQuestionId { get; set; }
    public QuestionnaireQuestion QuestionnaireQuestion { get; set; }

    public string TextKey { get; set; }
    public int Order { get; set; }
    public bool IsRequired { get; set; }
}
