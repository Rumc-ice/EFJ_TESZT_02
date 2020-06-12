using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
  
        public class Sajat_class
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }

            public string Nev { get; set; }

            public void setNev(string p_nev)
            {
                this.Nev = p_nev;
            }

        }
   
}
