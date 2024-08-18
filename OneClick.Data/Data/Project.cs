using OneClick.Domain.Domain.OneClickProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Data.Data
{
    public class Project
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? ProjectDomain { get; set; }
        public string? ProjectName { get; set; }
        public string? ServerIP { get; set; }
        public string? ServerName { get; set; }
        public int TraderMaxCount { get; set; }
        public int UserMaxCount { get; set; }
        public int TraderCount { get; set; }
        public int UserCount { get; set; }
        public int ProxyCount { get; set; }
        public int AdminCount { get; set; }
        public string? ProjectConfig { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Description { get; set; }
        public ProjectState State { get; set; }
        public int ProjectErrorCode { get; set; }
        public ProjectTaskState ProjectWorkerTask { get; set; }
        public int IsRun { get; set; }
        public int ProcessId { get; set; }
        public DateTime StartEngineDate { get; set; }
        public DateTime StopEngineDate { get; set; }
        public DateTime LastPing { get; set; }
        public string? WWWrootVersion { get; set; }
        public string? EngineVersion { get; set; }
        public bool Synchronized { get; set; }
        public virtual Payment? Payment { get; set; }
        public string? TelegramBot { get; set; }
        public string? TelegramKey { get; set; }
    }

    public enum ProjectTaskState
    {
        New,
        SourceRequestRelocation,
        SourceProjectFrozen,
        SourceDataBaseRequest,
        SourceDataBaseReady,
        DestinationProjectDownloaded,
        DestinationDataBaseDownloaded,
        DestinationDataBaseRestored,
        DestinationProjectReady,
        DnsRecordChanged,
        SourceProjectDeleteRequest,
        SourceProjectDeleted,
        RelocateFailure
    }
}
