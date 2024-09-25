using System.Globalization;

namespace Blazor.OneClick.Constants
{
    public static class Settings
    {
        public static string ConnectionString = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=OneClickWeb;User Id=monster;Password=qwerty111222333;Trusted_Connection=yes;TrustServerCertificate=True;";
        // public static string ConnectionString = "server=VDSWIN2K22\\SQLEXPRESS;Database=OneClickWeb;User Id=monster;Password=qwerty111222333;Trusted_Connection=no;TrustServerCertificate=True;";
        // public static string ConnectionString = "server=localhost;user=root;password=Guj7uGuj7u;database=OneClickWeb;";
        public static readonly CultureInfo[] SupportedCultures =
         {
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US"),
        };

        public static readonly string OneClickApiPort = "8080";
        public static readonly string OneClickServerLogin = "magicom@yandex.ru";
        public static readonly string OneClickServerPass = "Guj7uGuj7u!";

        //public static readonly string TelegramBotInit = "CopyTrader_Robot";
        //public static readonly string TelegramBotKeyInit = "5957597423:AAEQXtPTJjiMbhdLMKwbPpt5EIOxLCrX1TU";
        public static readonly string TelegramBotInit = "magicomTrader_bot";
        public static readonly string TelegramBotKeyInit = "6845717373:AAGPBo2mGTXPEHebCFiQvO5oULvg7j6RG00";
        public static readonly string TimeWebKey = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCIsImtpZCI6IjFrYnhacFJNQGJSI0tSbE1xS1lqIn0.eyJ1c2VyIjoieno4OTgzMyIsInR5cGUiOiJhcGlfa2V5IiwicG9ydGFsX3Rva2VuIjoiNjM5MGY1YTYtNDU3YS00MDc2LTk1ZjctYzk4MWRiZWMyYjgwIiwiYXBpX2tleV9pZCI6ImE5ZDA2Y2ZkLTU1ODEtNDRlZC1iODcyLWUyNDRlNzM3NmRlZCIsImlhdCI6MTcxMDc3NzEzMn0.xQSmwjWks1uNOAw9tF1M-be1FQZCrpvuVJA1tDRrGILWhILm1OQWkq80AZcy6OvYCbWQcxcAw0GOTdsu4qTqS-Em9ethvB94hGR7gp6nyEeuQakm8N7xksauNsSbLEOaBgr3CzrM7YQcxHIEXn2qlc-ygEMSfkGssyaMct9HE-GfZJ8kLNWSiW1X2dCSHr8IqfchaaRBFnQVaHZUQlGBhjrioc78dxpFB5ukn-hmn4p-w-Fl_nwqmtkA1c1Z5yz0DYdp6B2JjaJvzYz5ScRRlTRzEXcPdCkP_43i8vfmalH3hYZgNQLV6qZgKMSn4Fmul7CY5V0U7qYAduA6mwxS6zZSExYpxU6cO0nUc5fBBxUCJ6plg44yct4knwymGWPZfuZyezJfdUsNipCRD7p74_-Dq135jmsH0xKl2GKoj_gAOAyjrmeBkrQHjlCNVZqF_-InB0UcW6uIrLTrm3u4BEc4D35m8x7eGI_afhwsEx21T602oTbsbRlfou2T6ZxQ";

        public static readonly string OneClickDomain = "copytrader.pw";
        public static readonly string CabinetOneClickUrl = "https://cabinet.copytrader.pw/";
        public static readonly string OneClickUrl = "https://copytrader.pw/";

        public const string AdminRole = "Admin";
        public const string TraderRole = "Trader";
        public const string UserRole = "User";

        public const long AdminTelegramId = 163433124;
        //public const string AdminTelegram = "roman_magicom";

        public static List<long> ListTelegramForErrorSend = new List<long> { 860182978 };
        public static List<long> ListTelegramForCriticalErrorSend = new List<long> { 860182978, 163433124 };

        public static List<string> Roles = new List<string> { AdminRole, TraderRole, UserRole };
        public static List<string> ImmutableDomains = new List<string> { "sibhl.ru", "easytrading.pw", "copytrader.pw" };

        public static int TraderMaxForProject = 25;
        public static int InvestorMaxForProject = 500;


    }
}
