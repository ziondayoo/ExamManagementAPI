namespace ExamManagementAPI.Models.DTOs
{
    public class ExamToReturnDTO
    {
        public List<ObjectiveQuestion>? ObjectiveQuestions { get; set; }
        public List<TheoryQuestion>? TheoryQuestions { get; set; }

        public string? ExamName { get; set; }

        public int TotalScore { get; set; }
        public ExamStatus Status { get; set; }
    }
}
