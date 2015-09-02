using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class Add : Binop
    {
        public Expr E1;
        public Expr E2;

        override public string ToString()
        {
            return "(" + E1.ToString() + "+" + E2.ToString() + ")";
        }

        public Add(Expr e1, Expr e2)
        {
            E1 = e1;
            E2 = e2;
        }
    }
}
