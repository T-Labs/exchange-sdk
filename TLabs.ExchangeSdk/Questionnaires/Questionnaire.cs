using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Questionnaires;

public class Questionnaire
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public QuestionnaireType Type { get; set; } = QuestionnaireType.Risk;
    public string NameKey { get; set; }
    public List<QuestionnaireQuestion> Questions { get; set; } = new List<QuestionnaireQuestion>();
}

public enum QuestionnaireType
{
    Risk = 10,
}
