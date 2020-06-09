using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Class1
    {
        public static string space(int db)
        {
            string ret = "";
            for (int i = 0; i < db; i++)  ret += " "; 
            return ret;
        }
    }
}
