using System.ComponentModel.DataAnnotations;

namespace Dapper_Company.Models
{ 
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public int OrganizationId { get; set; }

        public string? OrganizationName { get; set; }

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public int PositionId { get; set; }

        public string? PositionName { get; set; }

        public decimal Salary { get; set; }
    }
}



//namespace Dapper_Company.Models
//{
//    public class Employee
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public int OrganizationId { get; set; }
//        public string OrganizationName { get; set; }
//        public Organization Organization { get; set; }
//        public int DepartmentId { get; set; }
//        public string DepartmentName { get; set; }
//        public Department Department { get; set; }
//        public int PositionId { get; set; }
//        public string PositionName { get; set; }
//        public Position Position { get; set; }
//        public string Gender { get; set; }
//        [Required]
//        [Range(0, double.MaxValue)]
//        public decimal Salary { get; set; }
//    }
//}
