namespace BlekingetrafikenTests.Utils
{
    /// <summary>
    /// Centralized configuration for the test suite.
    /// All URLs and test constants are defined here for easy maintenance.
    /// </summary>
    public static class TestConfig
    {
        public const string BaseUrl = "https://www.blekingetrafiken.se";
        public const string TicketsUrl = BaseUrl + "/biljetter/";
        public const string TravelInfoUrl = BaseUrl + "/reseinformation/";
        public const string CustomerServiceUrl = BaseUrl + "/kundservice/";
        public const string TimetablesUrl = BaseUrl + "/reseinformation/tidtabeller/";
        public const string StationsUrl = BaseUrl + "/reseinformation/stationer/";
        public const string ZonesUrl = BaseUrl + "/reseinformation/zoner/";
        public const string TrafficInfoUrl = BaseUrl + "/reseinformation/trafikinformation/";
        public const string AccessibilityUrl = BaseUrl + "/reseinformation/tillganglighet/";
    }
}
