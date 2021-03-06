﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class Mul : Binop
    {
        override public string ToString()
        {
            return "(" + E1.ToString() + "*" + E2.ToString() + ")";
        }

        public Mul(Expr e1, Expr e2)
        {
            E1 = e1;
            E2 = e2;
        }

        public override int Eval(List<Tuple<string, int>> env)
        {
            return E1.Eval(env) * E1.Eval(env);
        }

        public override Expr Simplify()
        {
            if ((E1 as CstI) != null && (E1 as CstI).Value == 0 || (E2 as CstI).Value == 0) return new CstI(0);
            else if ((E1 as CstI) != null && (E1 as CstI).Value == 1) return E2.Simplify();
            else if ((E2 as CstI) != null && (E2 as CstI).Value == 1) return E1.Simplify();
            
            return new Mul(E1.Simplify(), E2.Simplify());
        }
    }
}
