using Autofac;
using Autofac.Core;
using System;
using System.Linq;
using System.Reflection;
using UI.Services;
using UI.ViewModels.Interfaces;

namespace UI.IoC
{
    public static class Bootstrapper
    {
        private static ILifetimeScope _rootScope;
        private static IMainViewModel _mainViewModel;
        public static IViewModel RootVisual
        {
            get
            {
                if (_rootScope == null) Start();

                _mainViewModel = _rootScope.Resolve<IMainViewModel>();
                return _mainViewModel;
            }
        }
        public static void Start()
        {
            if (_rootScope != null) return;

            var builder = new ContainerBuilder();
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            builder.RegisterType<LoadKnifes>().As<ILoader>();
            builder.RegisterType<LoadSpacers>().As<ILoader>();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IServices).IsAssignableFrom(t))
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IViewModel).IsAssignableFrom(t))
                .AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(UI)))
            //    .Where(t => t.Namespace.Contains("ViewModels"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            _rootScope = builder.Build();
        }
        public static void Stop()
        {
            _rootScope.Dispose();
        }

        public static T Resolve<T>()
        {
            if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _rootScope.Resolve<T>(new Parameter[0]);
        }

        public static T Resolve<T>(Parameter[] parameters)
        {
            if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

            return _rootScope.Resolve<T>(parameters);
        }
    }
}
