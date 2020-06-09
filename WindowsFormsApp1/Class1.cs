using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Class1
    {
        public static string Space(int p_db)
        {
            string ret = "";
            for (int i = 0; i < p_db; i++)  ret += " "; 
            return ret;
        }
        public static int Kuldemeny__alap_ar(int p_suly,Boolean p_els)
        {
            return 0;
        }
        public static int Kuldemeny__kulonszolg_ar(string p_kulonszolgok)
        {
            int ret = 0;
            string[] ksz_tomb = p_kulonszolgok.Split(',');

            foreach (string ksz in ksz_tomb)
            {
                //a lekérdezett különszolgárakat +=ret
            }
            return ret;
        }
    }
}
