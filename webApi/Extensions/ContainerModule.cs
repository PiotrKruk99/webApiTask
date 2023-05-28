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
        }
    }
}
