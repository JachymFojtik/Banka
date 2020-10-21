using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Banka
{
  public class Uverovy : Ucet
    {
        public double ZbyvaSplatit { get; set; } //termínů
        public static double Sazba { get; set; }
        public int DobaSplatky { get; set; }
        public Uverovy(string jmeno, double z,int dobaSplatky)
        {
            Sazba = 0.12;
            DobaSplatky = dobaSplatky;
            Jmeno = jmeno;
            Zustatek = z;

            Anuita = Zustatek;
            double i =(1- Math.Pow((1 + Sazba),-(dobaSplatky) ));
            i = Sazba / i;
            Anuita = Math.Round(Anuita * i,2);

            ZbyvaSplatit = DobaSplatky;

        }
        public static double Mesic(Uverovy ucet,int pocetMesicu)
        {
            double d = 0;
            if (ucet.ZbyvaSplatit <= 0)
            {
                ucet.ZbyvaSplatit -= pocetMesicu;
                return Math.Round(ucet.Zustatek, 2);
            }
            if (pocetMesicu<=ucet.ZbyvaSplatit)
            {
                d = ucet.Zustatek - ucet.Anuita*pocetMesicu;
                ucet.ZbyvaSplatit -= pocetMesicu;
                return Math.Round(d, 2);
            }
            else
            {
                d = ucet.Zustatek - ucet.Anuita * (ucet.ZbyvaSplatit);
                ucet.ZbyvaSplatit = 0;
                return Math.Round(d, 2);
            }

        }
    }
}