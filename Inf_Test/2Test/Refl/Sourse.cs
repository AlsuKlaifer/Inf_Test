using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Refl
{
    public class Sourse
    {
        public int PublicField;
        private int PrivateField;
        public Sourse(int field)
        {
            PublicField = field;
        }
        public static void StaticMethod()
        {
            Console.WriteLine("Static method");
        }
    }
}
