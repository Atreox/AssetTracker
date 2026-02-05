namespace AssetTracker.Domain.Entities
{
    public class Employee
    {
      
        public int Id { get; set; } //PK

        public string FullName { get; set; }=null!; //Not null

        public string Email { get; set; } = null!;  //Not null

        public int DepartmentId { get; set; }

        public Department Deparment { get; set; } = null!;// FK; nullable istenmemiş ve departman silinince çalışanın silinmesi istenmiş.

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
