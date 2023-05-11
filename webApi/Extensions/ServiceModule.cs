using Autofac;
using System.Reflection;
using webApi.Services;

namespace webApi.Extensions
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;
            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
