using Microsoft.Extensions.Configuration;

namespace Testing
{
    public static class TestSettings
    {
        static TestSettings()
        {
            SetDefaultValues();
        }

        public static IConfiguration TestConfiguration { get; } =
            new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        public static int PageTimeout { get; set; }
        public static int FrameTimeout { get; set; }
        public static int ElementTimeout { get; set; }
        public static string HomeUrl { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }
        public static string ProductName { get; set; }
        public static string ProductNameAlt { get; set; }

        public static void SetDefaultValues()
        {
            PageTimeout = TryParseIntValue(TestConfiguration["Settings:Common:Timeouts:Page"]);
            FrameTimeout = TryParseIntValue(TestConfiguration["Settings:Common:Timeouts:Frame"]);
            ElementTimeout = TryParseIntValue(TestConfiguration["Settings:Common:Timeouts:Element"]);
            HomeUrl = TestConfiguration["Settings:Test:HomeUrl"];
            UserName = TestConfiguration["Settings:Test:User:Name"];
            UserPassword = TestConfiguration["Settings:Test:User:Password"];
            ProductName = TestConfiguration["Settings:Test:Product:Name"];
            ProductNameAlt = TestConfiguration["Settings:Test:Product:NameAlt"];
        }

        private static int TryParseIntValue(string valueFromTestSettings)
        {
            int.TryParse(valueFromTestSettings, out var value);
            return value;
        }
    }
}