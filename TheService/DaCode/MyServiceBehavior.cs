using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace TheService.DaCode
{
    public class MyServiceBehavior : IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {}

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {}

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var serviceDescriptionEndpoint in serviceDescription.Endpoints)
            {
                foreach (var operation in serviceDescriptionEndpoint.Contract.Operations)
                {
                    if (!operation.Behaviors.Any(x => x is MyOperationBehavior))
                    {
                        operation.Behaviors.Add(new MyOperationBehavior());
                    }
                }
            }
        }
    }
}