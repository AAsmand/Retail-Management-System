using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public interface IConcurrency
    {
         int Id { get; set; }
         int TimeStamp { get; set; }    
    }
}
