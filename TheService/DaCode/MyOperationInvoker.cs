using System;
using System.ServiceModel.Dispatcher;
using log4net;

namespace TheService.DaCode
{
    public class MyOperationInvoker : IOperationInvoker
    {
        private readonly IOperationInvoker _baseInvoker;
        private readonly ILog _log;

        public MyOperationInvoker(DispatchOperation dispatchOperation)
        {
            _baseInvoker = dispatchOperation.Invoker;
            _log = LogManager.GetLogger(GetType());
        }

        public object[] AllocateInputs()
        {
            return _baseInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            // The interception of request starts in the .svc markup file, Factory="TheService.DaCode.MyFactory" 
            // This is the corr id
            log4net.LogicalThreadContext.Properties["CorrelationId"] = Guid.NewGuid();

            _log.Info("Hello world!");

            var result = _baseInvoker.Invoke(instance, inputs, out outputs);

            _log.Info("Goodbye world!");

            return result;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _baseInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _baseInvoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous => _baseInvoker.IsSynchronous;
    }
}