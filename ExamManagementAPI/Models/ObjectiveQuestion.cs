namespace ExamManagementAPI.Models
{
    public class ObjectiveQuestion : BaseEntity
    {
        //public Exam? Exam { get; set; }
        public int QuestionNumber { get; set; }
        public string? Question { get; set; }
        public List<QuestionOptions>? QuestionOptions { get; set; }

        public ObjectiveQuestion()
        {
            QuestionOptions = new List<QuestionOptions>();
        }
    }
}
