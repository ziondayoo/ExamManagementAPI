namespace ExamManagementAPI.Models
{
    public class Exam:BaseEntity
    {
        
        public List<ObjectiveQuestion>? ObjectiveQuestions { get; set; }
        public List<TheoryQuestion>? TheoryQuestions { get; set; }

        public string? ExamName { get; set; }

        public int TotalScore { get; set; }
        public ExamStatus Status { get; set; }
        
        public Exam()
        {
            ObjectiveQuestions = new List<ObjectiveQuestion>();
            TheoryQuestions = new List<TheoryQuestion>();
        }
    }
}
