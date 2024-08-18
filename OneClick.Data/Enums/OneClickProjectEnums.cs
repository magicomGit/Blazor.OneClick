using System.ComponentModel;

namespace OneClick.Data.Enums
{
    public enum Severity
    {
        [Description("normal")]
        Normal,
        [Description("info")]
        Info,
        [Description("success")]
        Success,
        [Description("warning")]
        Warning,
        [Description("error")]
        Error
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
