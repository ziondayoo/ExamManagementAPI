
using ExamManagementAPI.Data;
using ExamManagementAPI.Models;
using ExamManagementAPI.Models.DTOs;
using ExamManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamManagementAPI.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly AppDataContext _ctx;

        public ExamService(AppDataContext appDataContext)
        {
            _ctx = appDataContext;
        }
        private async Task<bool> SavedAsync()
        {
            var valueToReturn = false;
            if (await _ctx.SaveChangesAsync() > 0)
                valueToReturn = true;
            else
                valueToReturn = false;

            return valueToReturn;
        }
        public async Task<bool> AddObjectiveQuestion(ObjectiveQuestion question)
        {
            await _ctx.ObjectiveQuestions.AddAsync(question);
            return await SavedAsync();

        }

        public async Task<bool> AddTheoryQuestion(TheoryQuestion question)
        {
            await _ctx.TheoryQuestions.AddAsync(question);

            return await SavedAsync();
        }

        public async Task<bool> DeleteObjectiveQuestion(string Id)
        {
            var question = await _ctx.ObjectiveQuestions.FindAsync(Id);
            _ctx.ObjectiveQuestions.Remove(question);
            return await SavedAsync();
        }

        public async Task<bool> DeleteTheoryQuestion(string Id)
        {
            var question = await _ctx.TheoryQuestions.FindAsync(Id);
            _ctx.TheoryQuestions.Remove(question);
            return await SavedAsync();
        }

        public async Task<Exam> GetExamById(string? id)
        {
            var result = await _ctx.Exams?.Where(x => x.Id == id).Include(y => y.ObjectiveQuestions)
                .Include(z => z.ObjectiveQuestions).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> MarkObjectiveQuestion(GetObjectiveQuestion question)
        {
            var getQuestion = await _ctx.ObjectiveQuestions.FindAsync(question.QuestionNo);
            if (getQuestion.Answer == question.Answer)
            {
                return true;
            }
            return false;
        }

        //public Task<bool> MarkTheoryQuestion(string questionId)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<bool> UpdateObjectiveQuestion(string Id)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> UpdateTheoryQuestion(string Id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> CreateExam(Exam exam)
        {
            await _ctx.Exams.AddAsync(exam);
            return await SavedAsync();
        }

        public async Task<bool> UpdateExam(Exam exam)
        {
            _ctx.Update(exam);
            return await SavedAsync();
        }

        //public async Task<IEnumerable<Exam>> GetAllExams()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
