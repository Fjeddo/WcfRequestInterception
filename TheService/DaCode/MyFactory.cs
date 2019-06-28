using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace TheService.DaCode
{
    public class MyFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            log4net.Config.XmlConfigurator.Configure();

            var serviceHost = new MyServiceHost(serviceType, baseAddresses);

            return serviceHost;
        }
    }
}