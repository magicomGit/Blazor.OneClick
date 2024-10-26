namespace OneClick.Domain.Enums.Project
{
    public enum ServerState
    {
        Frozen,
        Ok,
        Failure,
        Creating,
        Off,
        TurningOn,
        TurningOff,
        Rebooting,
    }

    public enum ServerProvider
    {
        Custom,
        TimeWeb,
    }

}
