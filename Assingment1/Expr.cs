using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    abstract class Expr
    {        
        abstract override public string ToString();

        abstract public int Eval(List<Tuple<String, int>> env);

        abstract public Expr Simplify();
    }
}
