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

        public override int Eval(List<Tuple<string, int>> env)
        {
            return env.Find(x => x.Item1.Equals(Value)).Item2;
        }

        public override Expr Simplify()
        {
            return this;
        }
    }
}
