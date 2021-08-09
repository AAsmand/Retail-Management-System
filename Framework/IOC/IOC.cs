using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Text;
using System.Threading;

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
            return new Container(x =>
            {
                x.AddRegistry<PluginsRegistry>();
            });
        }
        public static IContainer Container { get { return container.Value; } }
    }
}
