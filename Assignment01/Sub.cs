using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class Sub : Binop
    {
        override public string ToString()
        {
            return "(" + E1.ToString() + "-" + E2.ToString() + ")";
        }

        public Sub(Expr e1, Expr e2)
        {
            E1 = e1;
            E2 = e2;
        }

        public override int Eval(List<Tuple<string, int>> env)
        {
            return E1.Eval(env) - E2.Eval(env);
        }

        public override Expr Simplify()
        {
            if ((E2 as CstI) != null && (E2 as CstI).Value == 0) return E1.Simplify();
            
            return new Sub(E1.Simplify(), E2.Simplify());
        }
    }
}
