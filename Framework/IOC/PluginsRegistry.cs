using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.IOC
{
    class PluginsRegistry:Registry
    {
        public PluginsRegistry()
        {
            string p = Path.Combine(Environment.CurrentDirectory, "Plugins");
            this.Scan(scanner =>
            {
                scanner.AssembliesFromPath(
                    path: p
                    );
                //scanner.WithDefaultConventions();
                scanner.Convention<CustomConvention>();
            });
        }
    }
}
