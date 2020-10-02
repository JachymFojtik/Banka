using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka
{
    public class Sporici : Ucet
    {
        public Sporici(string jmeno, decimal z)
        {
            Jmeno = jmeno;
            Zustatek = z;
        }
        public Sporici(string jmeno)
        {
            Jmeno = jmeno;
            Zustatek = 0;
        }
    }
}
