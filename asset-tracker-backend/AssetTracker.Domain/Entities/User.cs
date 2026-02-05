namespace AssetTracker.Domain.Entities
{
    public class User
    {

        public int Id { get; set; } //PK

        public string Username { get; set; } = null!;//Not null unique

        public string Password { get; set; } = null!;//Not null (Zaman Kalırsa Hash)
    }
}
