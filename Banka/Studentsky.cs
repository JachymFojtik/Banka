using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka
{
    class Studentsky: Sporici
    {
        private bool vyberDnes = false;
        public Studentsky(string jmeno, decimal z)
        {
            Jmeno = jmeno;
            Zustatek = z;
        }
        public Studentsky(string jmeno)
        {
            Jmeno = jmeno;
            Zustatek = 0;
        }
    }
}
