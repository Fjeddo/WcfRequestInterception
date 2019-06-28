using System;
using System.ServiceModel;

namespace TheService.DaCode
{
    public class MyServiceHost : ServiceHost
    {
        public MyServiceHost(Type serviceType, Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {}

        protected override void OnOpening()
        {
            base.OnOpening();

            Description.Behaviors.Add(new MyServiceBehavior());
        }
    }
}