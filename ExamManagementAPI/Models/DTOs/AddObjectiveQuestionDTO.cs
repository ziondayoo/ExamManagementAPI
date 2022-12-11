namespace ExamManagementAPI.Models.DTOs
{
    public class AddObjectiveQuestionDTO
    {
        public int QuestionNumber { get; set; }
        public string? Question { get; set; }
        public List<QuestionOptions> QuestionOptions { get; set; }
    }
}
