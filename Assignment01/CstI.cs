﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class CstI : Expr
    {
        public int Value;
        override public string ToString()
        {
            return Value + "";
        }

        public CstI(int value)
        {
            Value = value;
        }

        public override int Eval(List<Tuple<string, int>> env)
        {
            return Value;
        }

        public override Expr Simplify()
        {
            return this;
        }
    }
}
