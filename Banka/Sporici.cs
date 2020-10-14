using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Banka
{
    public class Sporici : Ucet
    {
        private DateTime MonthNow;
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
        public override void Vybrat(string s)
        {
            try
            {
                int i = int.Parse(s);
                if (i > Zustatek)
                {
                    MessageBox.Show("SPOŘÍCÍ a STUDENTSKÝ ÚČET neumožňuje jít do mínusu");
                }
                else Zustatek -= i;
            }
            catch (Exception)
            {
                MessageBox.Show("Špatný formát");
            }

        }
    }
}
