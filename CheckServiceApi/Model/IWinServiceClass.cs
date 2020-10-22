using System.Collections.Generic;

namespace CheckServiceApi.Model
{
    public interface IWinServiceClass
    {
        void AddServertoList(string ServerName, string ServicesList);
        IEnumerable<WinServiceModel> GetCamstarServices();
        void GetCamstarServicesForServer(string ServerName);
        void UpdateServerInfo(string ServerName, string ServicesList);
    }
}