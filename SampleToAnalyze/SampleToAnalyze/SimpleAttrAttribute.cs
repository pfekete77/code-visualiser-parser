using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleToAnalyze
{
    // set this to be a class-only attribute
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleAttrAttribute : Attribute
    {
        public int IntProp { get; protected set; }

        public string StringProp { get; protected set; }

        public SimpleAttrAttribute(int intProp, string stringProp)
        {
            IntProp = intProp;
            StringProp = stringProp;
        }
    }
}
