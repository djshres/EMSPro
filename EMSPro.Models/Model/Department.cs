using System.ComponentModel.DataAnnotations;

namespace EMSPro.Models.Model
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
