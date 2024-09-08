namespace Cashing.Models
{
    public class AppConfigrationsModel
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }
        public bool IsDebugMode { get; set; }
    }
}
