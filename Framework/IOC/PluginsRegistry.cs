using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.IOC
{
    class PluginsRegistry : Registry
    {
        public PluginsRegistry()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "lock.txt"));
            this.Scan(scanner =>
            {
                scanner.AssembliesFromPath(
                    path: Path.Combine(Environment.CurrentDirectory, "Plugins"),
                    assemblyFilter:p=> !lines.Any(l => p.FullName.Contains(l))
                    );
                scanner.Convention<CustomConvention>();
            });
        }
    }
}
