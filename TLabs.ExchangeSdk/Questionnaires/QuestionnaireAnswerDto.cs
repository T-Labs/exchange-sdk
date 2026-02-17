using System;
using System.Collections.Generic;

public class QuestionnaireAnswerDto
{
    public string UserId { get; set; }
    public Guid QuestionnaireId { get; set; }
    public List<QuestionnaireQuestionAnswerDto> Questions { get; set; }
    public string Locale { get; set; }
}
