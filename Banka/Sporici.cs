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
        public static double Sazba { get; set; }
        public Sporici(string jmeno, double z)
        {
            Sazba = 0.02;
            Jmeno = jmeno;
            Zustatek = z;
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
