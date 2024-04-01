using System.ComponentModel.DataAnnotations;

namespace EMSPro.Models.Model
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        [Required]
        public int PerformanceScore { get; set; }
        public string Comments { get; set; }
    }
}
