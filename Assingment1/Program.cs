using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new Add(new CstI(17), new Var("z"));
            var e1 = new Mul(new Add(new CstI(17), new Var("b")), new Var("z"));
            var e2 = new Add(new Add(new Add(new Add(new CstI(17), new Var("z")), new Var("z")), new Var("z")), new Var("z"));

            Console.WriteLine(e);
            Console.WriteLine(e1);
            Console.WriteLine(e2);

        }
    }
}
