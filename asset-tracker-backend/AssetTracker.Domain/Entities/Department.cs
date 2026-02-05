
namespace AssetTracker.Domain.Entities
{
   
    public class Department
    {
     
        public int Id { get; set; } //PK
        public string DeptName { get; set; } = null!; //Unique not null
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
