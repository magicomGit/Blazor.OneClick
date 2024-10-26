using OneClick.Domain.Enums.Project;

namespace OneClick.Data.Data
{
    public class OneClickServer
    {
        public int Id { get; set; }
        public int ProviderServerId { get; set; }
        public bool IsRun { get; set; }
        public string? IpAddress { get; set; }
        public int Port { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ProjrctCount { get; set; }
        public int PowerMax { get; set; }
        public int ReservedByTraders { get; set; }
        public int ReservedByUsers { get; set; }
        public int UsedByTraders { get; set; }
        public int UsedByUsers { get; set; }
        public ServerState State { get; set; }
        public ServerProvider Provider { get; set; }
        public DateTime UpdaterLastPing { get; set; }
        public string? EngineVersion { get; set; }
        public string? WWWVersion { get; set; }
        public string? OS { get; set; }
        public int RAM { get; set; }
        public virtual ServerDisk? Disk { get; set; }

    }

    public class ServerDisk
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }
    }
}
