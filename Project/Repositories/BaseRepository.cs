using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BaseRepository
    {
        public virtual bool IsNotConcurrent(IConcurrency model)
        {
            return true;
        }
    }
}
