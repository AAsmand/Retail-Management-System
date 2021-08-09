using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public interface IBase
    {

    }
    public interface IStructureMapperConfig
    {

        Dictionary<Type,Type> GetType();
    }
}
