using CloudFlare.Client.Enumerators;

namespace OneClick.Data.Data
{
    public class ProjectDomain
    {
        public long Id { get; set; }
        public string CloudId { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string Name { get; set; }
        public string? ServerIP { get; set; }
        public string? Account { get; set; }
        public string? Plan { get; set; }
        public DateTime? ActivationDate { get; set; }
        public ZoneStatus Status { get; set; }

        public List<string>? NameServers { get; set; }
    }
}
