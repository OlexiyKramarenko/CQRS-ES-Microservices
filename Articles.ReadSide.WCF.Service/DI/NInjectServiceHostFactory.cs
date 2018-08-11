using Articles.ReadSide.Repository;
using AutoMapper;
using MongoDB.Driver;
using Ninject;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCF.Service.Host
{
    public class NInjectServiceHostFactory : ServiceHostFactory
    {
        private readonly IKernel kernel;
        public NInjectServiceHostFactory()
        {
            kernel = new StandardKernel();
            kernel.Bind<IArticlesRepository>().To<ArticlesRepository>();
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            kernel.Bind<IMongoDatabase>().ToMethod(a => client.GetDatabase("test"));
            kernel.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                //config.CreateMap<MySource, MyDest>();
                // .... other mappings, Profiles, etc.              

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new NInjectServiceHost(kernel, serviceType, baseAddresses);
        }
    }

    public class NInjectServiceHost : ServiceHost
    {
        public NInjectServiceHost(IKernel kernel, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new NInjectInstanceProvider(kernel));
            }
        }
    }

    public class NInjectInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IKernel kernel;
        public NInjectInstanceProvider(IKernel kernel)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            this.kernel = kernel;
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return kernel.Get(instanceContext.Host.Description.ServiceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            kernel.Release(instance);
        }

        public void AddBindingParameters(ContractDescription contractDescription,
            ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ContractDescription contractDescription,
            ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { }

        public void ApplyDispatchBehavior(ContractDescription contractDescription,
            ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        { }
    }
}

