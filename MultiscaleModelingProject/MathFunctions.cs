using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    class MathFunctions
    {
        public static int MathMod(int a, int b)
        {
            return ((a % b) + b) % b;
        }
    }
}
