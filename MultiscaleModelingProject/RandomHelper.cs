using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public static class RandomHelper
    {
        private static Random random = new Random();

        public static int Next()
        {
            return RandomHelper.random.Next();
        }

        public static int Next(int maxValue)
        {
            return RandomHelper.random.Next(maxValue);
        }
    }
}
