namespace Blazor.OneClick.Constants
{
    public class Enums
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


        public enum ProjectTariff
        {
            Start = 1,
            Company = 2,

        }


        public enum ExchangeMarket
        {
            None = 0,
            Binance = 10,
            Bybit = 20,
            FTX = 30,
            Huobi = 40,
            Kraken = 50,
            Kucoin = 60,
            Okex = 70,
            Bitget = 80
        }

        //public enum  UserRoles
        //{
        //    User,       
        //    Trader,
        //    Admin,
        //}

        public enum UserStatus
        {
            Frozen,
            AwaitPay,
            Active,
            None
        }

        public enum Payments
        {
            AdminPayment,
            Cryptomus
        }

        public enum ReminderSet
        {
            None,
            Everyday,
            OnceAWeek,
            TwiceAWeek,
            OnceAMonth,
            TwiceAMonth,
            AfterRegister

        }

        public enum BillingPeriod
        {
            None,
            Everyday,
            OnceAWeek,
            TwiceAWeek,
            OnceAMonth,
            TwiceAMonth,

        }


        public enum SystemSettings
        {
            ServicesPrice,
            AppSettings,
            AdminId,
            BillingSettings,
            DefaultAvatar,
            SystemLogo

        }

        public enum LogType
        {
            Error,
            Info,
            CriticalError,
            Transaction
        }

        public enum LogStatus
        {
            New,
            Sent,
            Resolved

        }

        public enum ProjectError
        {
            None,
            DataBaseCreateError,
            EngineCreateError,
            DataBaseConfigureError,
            DataBaseDeletingError,
            RelocateFailure
        }
        public enum ServerProvider
        {
            Custom,
            TimeWeb,
        }
    }
}
