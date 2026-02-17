using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Questionnaires;

public class QuestionnaireQuestion
{
    public Guid Id { get; set; }
    public Guid QuestionnaireId { get; set; }
    public Questionnaire Questionnaire { get; set; }
    public string TextKey { get; set; }
    public int Order { get; set; }
    public List<QuestionnaireQuestionOption> Options { get; set; } = new List<QuestionnaireQuestionOption>();
    public bool IsMultipleChoice { get; set; }
    public bool IsSensitiveLegal { get; set; }
}
