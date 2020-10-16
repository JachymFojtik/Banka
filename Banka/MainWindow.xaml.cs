using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Banka
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ucet> Ucty = new List<Ucet>();
        public DateTime datum = DateTime.Now;
        public string vyber;
        public MainWindow()
        {
            InitializeComponent();

            List<string> Data = new List<string>();
            try
            {
                string[] f = File.ReadAllLines("ucty.txt");
                foreach (var item in f)
                {
                    Data.Add(item);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Databáze účtů nenalezena");
            }

            foreach (var item in Data)
            {
                string[] s = item.Split('-');
                switch (s[0])
                {
                    case "Spořící":
                        Ucty.Add(new Sporici(s[1], int.Parse(s[2])));
                        break;
                    case "Úvěrový":
                        Ucty.Add(new Uverovy(s[1], int.Parse(s[2])));
                        break;
                    case "Studentský":
                        Ucty.Add(new Studentsky(s[1], int.Parse(s[2])));
                        break;
                    default:
                        break;
                }
            }

            Studentsky stud1 = new Studentsky("Honza", 100);
            Uverovy s2 = new Uverovy("Petr", 500);
            Sporici s1 = new Sporici("Jachym",400);

            Ucty.Add(s1);
            Ucty.Add(s2);
            Ucty.Add(stud1);

            lDatum.Content = $"Aktuální datum: {datum.ToString("dd. MMMM yyyy")}";

            for (int i = 1; i <= 31; i++)
            {
                cbDny.Items.Add(i);
                if (i<=12)
                {
                    cbMesic.Items.Add(i);
                }
            }

            foreach (var inst in Ucty)
            {
                lbUcty.Items.Add(inst.Jmeno);
            }

            try
            {
                vyber = lbUcty.SelectedItem.ToString();
                lNazev.Content = $"Název účtu: {vyber}";

            }
            catch (Exception)
            {
                vyber = "";
            }

        }
        private void LbUcty_SelectionChanged(object sender, SelectionChangedEventArgs e)//DONE
        {
            vyber = lbUcty.SelectedItem.ToString();
            lNazev.Content = $"Název účtu: {vyber}";
            foreach (var inst in Ucty)
            {
                if (inst.Jmeno == lbUcty.SelectedItem.ToString())
                {
                    lZustatek.Content = "Zůstatek: " + inst.Zustatek.ToString();
                    switch (inst.GetType().ToString())
                    {
                        case "Banka.Sporici":
                            lTyp.Content = $"Typ účtu: Spořící (sazba = {Ucet.Sazba * 100} p. a.)";
                            break;
                        case "Banka.Studentsky":
                            lTyp.Content = $"Typ účtu: Studentský (sazba = {Ucet.Sazba * 100} p. a.)";
                            break;
                        case "Banka.Uverovy":
                            lTyp.Content = $"Typ účtu: Úvěrový (sazba = {Ucet.Sazba * 100} p. a.)";
                            break;
                        default:
                            lTyp.Content = $"Typ účtu: ERROR";
                            break;
                    }
                }

            }
        }

        private void bPridat_Click(object sender, RoutedEventArgs e)//DONE
        {
            if (lbUcty.SelectedItem != null)
            {
                foreach (var inst in Ucty)
                {
                    if (inst.Jmeno == lbUcty.SelectedItem.ToString())
                    {
                        inst.Pridat(tbPridat.Text);
                        lZustatek.Content = "Zůstatek: " + inst.Zustatek.ToString();
                        break;
                    }
                }
            }
            else MessageBox.Show("Vyberte účet, kam vkládáte");

        }

        private void bCas_Click(object sender, RoutedEventArgs e)//DONE
        {
            try
            {
                datum = datum.AddDays(int.Parse(cbDny.SelectedItem.ToString()));
                lDatum.Content = $"Aktuální datum: {datum.ToString("dd. MMMM yyyy")}";
            }
            catch (Exception)
            {
                MessageBox.Show("Vyberte, o kolik dní chcete čas posunout");
            }

        }
        private void bVybrat_Click(object sender, RoutedEventArgs e)//DONE
        {

            if (lbUcty.SelectedItem != null)
            {
                foreach (var inst in Ucty)
                {
                    if (inst.Jmeno == lbUcty.SelectedItem.ToString())
                    {
                        if (inst is Studentsky)
                        {
                            Studentsky s = (Studentsky)inst;
                            s.Vybrat(tbPridat.Text, datum);

                        }
                        else inst.Vybrat(tbPridat.Text);

                        lZustatek.Content = "Zůstatek: " + inst.Zustatek.ToString();
                        break;

                    }

                }

            }
            else MessageBox.Show("Vyberte účet, ze kterého vybíráte");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegWin Reg = new RegWin();
            Reg.Show();
            Close();
        }
        private void NovyMesic(List<Ucet> lUcty, int pocetMesicu)
        {
            foreach (var ucet in lUcty)
            {
                if (ucet is Uverovy)
                {
                    //Tady napiš tu operaci jak se to úrokuje==============================================================================================================
                }
                else
                {
                    ucet.Zustatek += Math.Round((decimal)Ucet.Sazba * ucet.Zustatek* pocetMesicu,2) ;
                }
                if (lbUcty.SelectedItem.ToString() == ucet.Jmeno)
                {
                    lZustatek.Content = "Zůstatek: " + ucet.Zustatek.ToString();
                }
            }

        }

        private void bMesic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pocetMesicu = int.Parse(cbMesic.SelectedItem.ToString());
                datum = datum.AddMonths(pocetMesicu);
                lDatum.Content = $"Aktuální datum: {datum.ToString("dd. MMMM yyyy")}";
                NovyMesic(Ucty,pocetMesicu);
            }
            catch (Exception)
            {
                MessageBox.Show("Vyberte, o kolik dní chcete čas posunout");
            }
        }
    }

    public class Ucet//done
    {
        public static double Sazba = 0.02; //stejná u úrokového i spořícího
        public decimal Zustatek { get; set; }
        public string Jmeno { get; set; }

        public virtual void Pridat(string s)
        {
            try
            {
                int i = int.Parse(s);
                Zustatek += i;
            }
            catch (Exception)
            {
                MessageBox.Show("Špatný formát");
            }
        }
        public virtual void Vybrat(string s)
        {
            try
            {
                int i = int.Parse(s);
                Zustatek -= i;
            }
            catch (Exception)
            {
                MessageBox.Show("Špatný formát");
            }
        }
    }

}