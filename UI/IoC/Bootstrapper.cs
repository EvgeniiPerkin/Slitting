using Autofac;
using System.Linq;
using System.Reflection;
using UI.Services;

namespace UI.IoC
{
    public static class Bootstrapper
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            builder.RegisterType<LoadKnifes>().As<ILoader>();
            builder.RegisterType<LoadSpacers>().As<ILoader>();


            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IServices).IsAssignableFrom(t))
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(UI)))
                .Where(t => t.Namespace.Contains("ViewModels"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            return builder.Build();
        }
    }
}
