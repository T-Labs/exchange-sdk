using System;
using System.Collections.Generic;

public class QuestionnaireQuestionAnswerDto
{
    public Guid QuestionId { get; set; }
    public string QuestionText { get; set; }
    public List<QuestionnaireQuestionOptionAnswerDto> Options { get; set; }
}
