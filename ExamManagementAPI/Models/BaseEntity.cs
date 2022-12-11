using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamManagementAPI.Models
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedBy { get; set; } = DateTime.Now;
        public DateTime UpdatedBy { get; set; } = DateTime.Now;
    }
}
