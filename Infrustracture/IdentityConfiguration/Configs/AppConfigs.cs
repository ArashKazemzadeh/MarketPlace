namespace WebApplication3.Configs
{
    public class AppConfigs
    {
    }


    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public string ConnectionString { get; set; }
        public int maximumOrderPerday { get; set; }
        public bool applicationshutdownstate { get; set; }
        public Configs configs { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Configs
    {
        public int number { get; set; }
        public bool state { get; set; }
    }

}
