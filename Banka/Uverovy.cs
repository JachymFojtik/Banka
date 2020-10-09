using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka
{
    class Uverovy : Ucet
    {
        public Uverovy(string jmeno, decimal z)
        {
            Jmeno = jmeno;
            Zustatek = z;
        }
        public Uverovy(string jmeno)
        {
            Jmeno = jmeno;
            Zustatek = 0;
        }
    }
}