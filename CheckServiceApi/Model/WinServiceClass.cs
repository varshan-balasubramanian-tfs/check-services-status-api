using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CheckServiceApi.Model
{
    public class WinServiceClass : IWinServiceClass
    {
        private readonly IConfiguration Configuration;
        private string _ServerListPath;

        public WinServiceClass(IConfiguration configuration)
        {
            Configuration = configuration;
            _ServerListPath = Configuration.GetValue<string>("ServerList");
        }

        public void AddServertoList(string ServerName, string ServicesList)
        {
            throw new NotImplementedException();
        }

        public void UpdateServerInfo(string ServerName, string ServicesList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WinServiceModel> GetCamstarServices()
        {
            List<WinServiceModel> _serviceDetailsList = new List<WinServiceModel>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_ServerListPath);
            XmlNodeList ServerNodeList = xmlDocument.GetElementsByTagName("Name");
            try
            {
                foreach (XmlNode serverNode in ServerNodeList)
                {
                    List<ServiceController> _camServices = new List<ServiceController>();
                    string _serverName = serverNode.InnerXml.Trim().ToUpper();
                    string _camstarServices = serverNode.NextSibling.InnerXml.Trim();
                    if (_camstarServices.ToUpper() != "ALL")
                    {
                        foreach (string _service in _camstarServices.Split(','))
                        {
                            ServiceController _serviceController = ServiceController.GetServices(_serverName).Where(x => x.ServiceName == _service).FirstOrDefault();
                            _camServices.Add(_serviceController);
                        }
                    }
                    else
                    {
                        _camServices = ServiceController.GetServices(_serverName).Where(x => x.DisplayName.StartsWith("Camstar")).ToList();
                    }
                    foreach (ServiceController _camService in _camServices)
                    {
                        WinServiceModel serviceModel = new WinServiceModel()
                        {
                            ServerName = _camService.MachineName.ToString(),
                            ServiceDisplayName = _camService.DisplayName.ToString(),
                            ServiceName = _camService.ServiceName.ToString(),
                            ServiceStatus = _camService.Status.ToString()
                        };
                        _serviceDetailsList.Add(serviceModel);
                    }
                }
                return _serviceDetailsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCamstarServicesForServer(string ServerName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_ServerListPath);
            XElement element = XElement.Parse(xmlDocument.ToString());
            var result = element.Elements("Data").Elements("Server").Where(x => x.Name == ServerName);
        }
    }
}
