namespace Blazor.OneClick.Models
{
    public class IPCounter
    {
        public int Count { get; set; }
        public string? IPAddress { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
