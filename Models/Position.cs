namespace Dapper_Company.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public Department? Department { get; set; }
    }
}
