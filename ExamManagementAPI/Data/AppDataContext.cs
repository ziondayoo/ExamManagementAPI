using ExamManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamManagementAPI.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<TheoryQuestion> TheoryQuestions { get; set; }
        public DbSet<ObjectiveQuestion> ObjectiveQuestions  { get; set; }
    }
}
