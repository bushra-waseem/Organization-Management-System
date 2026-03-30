using System.ComponentModel.DataAnnotations;

namespace Dapper_Company.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string? Name { get; set; }
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
    }
}
