using ExamManagementAPI.Models;

namespace ExamManagementAPI.Services.Interfaces
{
    public interface IExamService
    {
        Task<bool> AddTheoryQuestion(TheoryQuestion question);
        Task<bool> DeleteTheoryQuestion(string Id);
        Task<bool> UpdateTheoryQuestion(string Id);


        Task<bool> AddObjectiveQuestion(ObjectiveQuestion question);
        Task<bool> DeleteObjectiveQuestion(string Id);
        Task<bool> UpdateObjectiveQuestion(string Id);

        Task<bool> MarkTheoryQuestion(string questionId);
        Task<bool> MarkObjectiveQuestion(string questionId);

        Task<bool> CreateExam(Exam exam);
        Task<bool> UpdateExam(Exam exam);
        Task<Exam> GetExamById(string id);
        Task<IEnumerable<Exam>> GetAllExams();
    }
}
