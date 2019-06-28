using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TheService.DaCode
{
    public class MyOperationBehavior : IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {}

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new MyOperationInvoker(dispatchOperation);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {}

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {}
    }
}