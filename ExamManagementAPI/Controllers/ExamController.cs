using ExamManagementAPI.Models;
using ExamManagementAPI.Models.DTOs;
using ExamManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ExamManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        [Route("create-exam")]
        public async Task<IActionResult> CreateExam(CreateExamDTO exam)
        {
            var examToAdd = new Exam() { ExamName = exam.ExamName };
            var result = await _examService.CreateExam(examToAdd);
            return result ? Ok(exam) : BadRequest("exam could not be created");
        }
        [HttpPost]
        [Route("add-theory-question/{examId}")]
        public async Task<IActionResult> AddTheoryQuestion([FromBody] AddTheoryQuestionDTO question, string examId)
        {
            var exam = await _examService.GetExamById(examId);
            var questionToAdd = new TheoryQuestion() { Question = question.Question, QuestionNumber = question.QuestionNumber };
            exam?.TheoryQuestions?.Add(questionToAdd);
            var result = await _examService.UpdateExam(exam);
            return result ? Ok("question added successfully") : BadRequest("could not add question");
        }

        [HttpPost]
        [Route("add-objective-question/{examId}")]
        public async Task<IActionResult> AddObjectiveQuestion([FromBody] AddObjectiveQuestionDTO question, string examId)
        {
            var exam = await _examService.GetExamById(examId);
            var questionToAdd = new ObjectiveQuestion() { QuestionNumber = question.QuestionNumber, Question = question.Question, QuestionOptions = question.QuestionOptions };


            exam?.ObjectiveQuestions?.Add(questionToAdd);
            var result = await _examService.UpdateExam(exam);
            return result ? Ok("question added successfully") : BadRequest("could not add question");

        }

        [HttpGet]
        [Route("get-all-exams")]
        public async Task<IActionResult> GetAllExams()
        {
            var result = await _examService.GetAllExams();

            return Ok(result);
        }
    }
}
