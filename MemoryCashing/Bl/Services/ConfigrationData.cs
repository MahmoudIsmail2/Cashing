using Cashing.Bl.Interfaces;
using Cashing.Models;

namespace Cashing.Bl.Services
{
    public class ConfigrationData : IConfigrationData
    {
        public AppConfigrationsModel GetConfigrations()
        {

            // simulate Data Retriveing Will Take 5 Seconds
            Thread.Sleep(5000);
            // return Dummy Data
            return new AppConfigrationsModel
            {
                AppName = "Cashing",
                Version = "1.0.0",
                IsDebugMode = true,
                DatabaseConnectionString="server=localhost;database=cashing;user=root;password=123456"   
            };
        }

        public void SetConfigrations(AppConfigrationsModel configrations)
        {
            throw new NotImplementedException();
        }
    }
}
