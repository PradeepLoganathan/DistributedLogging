using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyLogger;

namespace LogGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLogger l = new TestLogger();
            l.Test();
        }
    }

    public class GUIDCorrelationProvider : ICorrelationProvider
    {
        Guid _guid;
        public string CorrelationID
        {
            get
            {
                return _guid.ToString(); 
            }

            set
            {
                _guid = Guid.NewGuid();
            }
        }
    }
    class TestLogger
    {
        Log _log;

        public TestLogger()
        {
            _log = new Log(new GUIDCorrelationProvider());
        }
        public void Test()
        {
            for (int i = 0; i < 10000; i++)
                _log.LogDebug(String.Format("This is {0}", i));
        }
    }
}
