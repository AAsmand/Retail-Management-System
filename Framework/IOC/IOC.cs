using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Text;
using System.Threading;
using Project.ViewModel;
using Castle.Core;
using Castle.DynamicProxy;
using Framework.BaseBusiness;

namespace Framework.IOC
{
    public static class IOC
    {
        private static Lazy<Container> container;
        static IOC()
        {
            container = new Lazy<Container>(buildContainer, LazyThreadSafetyMode.ExecutionAndPublication);
        }
        private static Container buildContainer()
        {
            var dynamicProxy = new ProxyGenerator();
            return new Container(x =>
            {
                x.AddRegistry<PluginsRegistry>();
                x.For<IConcurrencyChecker>().DecorateAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new ConcurrencyInterceptor()));
            });
        }
        public static IContainer Container { get { return container.Value; } }
    }
}
