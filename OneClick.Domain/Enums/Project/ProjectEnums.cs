namespace OneClick.Domain.Enums.Project
{
    public enum ProjectTariff
    {
        Start = 1,
        Company = 2,
    }

    public enum ProjectState
    {
        NewProjectRequest,
        Creating,
        CreatingFailure,
        Ready,
        Deleted,
        Frozen,
        DeleteProjectRequest,
        DeletingFailure,
        FrozenByAdmin,
        ChangeStateProcess,
        ChangeStateError,
        SourceRelocateRequest,
        DestinationRelocateRequest,
        RelocateSucceed,
        FrozenByOwner,
        FullDeleteProjectRequest
    }

    public enum ExchangeMarket
    {
        None = 0,
        Binance = 10,
        BingX = 90,
        Bitget = 80,
        Bybit = 20,
        Kucoin = 60,
        OKX = 70,
    }
    public enum OtherSettings
    {
        Billing,
        CrossTrading
    }
}
