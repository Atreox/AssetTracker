namespace AssetTracker.Domain.Entities
{
    public class Asset
    {
 
        public int Id { get; set; }

        public string AssetName { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public string AssetType { get; set; } = null!;

        public DateTime PurchaseDate {  get; set; }
        public Employee? Employee { get; set; }

        public int? EmployeeId { get; set; }
    }
}
