namespace OneClick.Data.Data
{
    public class Referral
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public string? ParentId { get; set; }
        public int Level { get; set; }

    }
}
