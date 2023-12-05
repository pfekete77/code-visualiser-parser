using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleToAnalyze.SubNamespace
{
    [SimpleAttr(5, "Hello World")]
    public class SimpleClassToAnalyze
    {
        public int MySimpleProperty { get; set; }

        public event Action<object> MySimpleEvent;

        public int MySimpleMethod(string str, out bool flag, int i = 5)
        {
            flag = true;

            return 5;
        }
    }
}
