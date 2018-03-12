using System;
using System.Collections.Generic;
using System.Text;

namespace functionalcsharp.ch3
{
    class anonymousfunclambda
    {
        public static Func<Object, Object, bool> ilt_int = (a, b) => ((int)a > (int)b);
        public static Func<Object, Object, bool> ilt_string = (a, b) => ((char)a > (char)b);
    }
}
