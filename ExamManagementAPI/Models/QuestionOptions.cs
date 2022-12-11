namespace ExamManagementAPI.Models
{
    public class QuestionOptions { 
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string? OptionName { get; set; }
        public string? OptionContent { get; set; }
    }
}
