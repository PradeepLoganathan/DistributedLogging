using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyLogger
{
    public interface ICorrelationProvider
    {
        string CorrelationID{ get; set; }
    }
}
