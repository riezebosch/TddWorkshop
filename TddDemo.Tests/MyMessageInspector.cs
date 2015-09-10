using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace TddDemo.Tests
{
    class MyMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Debug.WriteLine(request);
            var correlation = Guid.NewGuid();
            return correlation;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Debug.WriteLine(reply);
        }
    }

    class MyMessageInspectorServiceBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cd in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (var ep in cd.Endpoints)
                {
                    ep.DispatchRuntime.MessageInspectors.Add(new MyMessageInspector());
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

}
