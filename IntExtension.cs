using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Session_01
{
    public static class IntExtension
    {
        public static int Square(this int number)
        {
            return number * number;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
