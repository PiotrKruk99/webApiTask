using Autofac;
using Microsoft.Extensions.Configuration;

namespace webApi.Extensions
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
            //builder.RegisterModule<CommandModule>();
            //builder.RegisterModule(new MongoModule(_configuration));
            //builder.RegisterModule(new AXModule(_configuration));
            //builder.RegisterModule<MachineServiceModule>();
            //builder.RegisterModule<RepositoryModule>();
            //builder.RegisterModule<AggregateServiceModule>();
            //builder.RegisterModule(new RabbitMQModule(_configuration));
            //builder.RegisterModule<HandlerModule>();
        }
    }
}
