using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.IOC
{
    class CustomConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {

            foreach (var type in types.AllTypes())
            {
                if (type.IsAbstract || !type.IsClass || type.FullName.Contains("ViewModel"))
                    return;
                Type interfaceType = type.GetInterface("I" + type.Name);
                Type madule = type.GetInterface("IMadule");
                if (interfaceType != null)
                    registry.For(interfaceType).Use(type);
                else
                    registry.For(type).Use(type);
                if (madule != null)
                    registry.For(madule).Use(type);
            }
        }
    }
}
