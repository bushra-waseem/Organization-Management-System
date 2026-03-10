using System.ComponentModel.DataAnnotations;

namespace Dapper_Company.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        public string? Name { get; set; }
    }
}
