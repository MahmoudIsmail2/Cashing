using Cashing.Models;

namespace Cashing.Bl.Interfaces
{
    public interface IConfigrationData
    {
        public AppConfigrationsModel GetConfigrations();
        public void SetConfigrations(AppConfigrationsModel configrations);
    }
}
