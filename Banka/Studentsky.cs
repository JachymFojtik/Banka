using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Banka
{
    class Studentsky : Sporici
    {
        private DateTime dnes;
        public bool vybranoDnes = false;
        public Studentsky(string jmeno, decimal z) : base(jmeno, z)
        {
            Jmeno = jmeno;
            Zustatek = z;
            vybranoDnes = false;
        }
        public Studentsky(string jmeno) : base(jmeno)
        {
            Jmeno = jmeno;
            Zustatek = 0;
            vybranoDnes = false;
        }
        public void VybratS(string s, DateTime d)
        {
            if (d.Day == dnes.Day)
                MessageBox.Show("Skrze STUDENTSKÝ ÚČET lze vybrat pouze 1x denně");

            else
                Vybrat(s);
            dnes = d;
        }
    }

}
