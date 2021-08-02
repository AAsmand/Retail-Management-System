using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public interface IConcurrencyChecker
    {
        bool IsValid(IConcurrency model);
    }
}
