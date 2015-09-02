using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class Var : Expr
    {
        public string Value;
        override public string ToString()
        {
            return Value + "";
        }

        public Var(string value)
        {
            Value = value;
        }
    }
}
