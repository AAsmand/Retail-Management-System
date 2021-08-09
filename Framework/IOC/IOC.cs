using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Text;

namespace Framework.IOC
{
    public static class IOC
    {
        public static Container Container;
        static IOC()
        {
            Container = new Container(c =>
            {
                c.AddRegistry<PluginsRegistry>();
            });
        }
    }
}
