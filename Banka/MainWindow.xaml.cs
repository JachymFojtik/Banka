using System;
using System.Collections.Generic;
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


            Studentsky stud1 = new Studentsky("Honza", 100);
            Uverovy s2 = new Uverovy("Petr", 500);
            Sporici s1 = new Sporici("Jachym");

            Ucty.Add(s1);
            Ucty.Add(s2);
            Ucty.Add(stud1);


            lDatum.Content = $"Aktuální datum: {datum.ToString("dd. MMMM yyyy")}";

            for (int i = 1; i <= 31; i++)
            {
                cbCisla.Items.Add(i);
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
                datum = datum.AddDays(int.Parse(cbCisla.SelectedItem.ToString()));
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
                            s.VybratS(tbPridat.Text, datum);

                        }
                        else
                        {
                            inst.Vybrat(tbPridat.Text);
                        }
                        lZustatek.Content = "Zůstatek: " + inst.Zustatek.ToString();
                        break;

                    }

                }

            }
            else MessageBox.Show("Vyberte účet, ze kterého vybíráte");
        }
    }

    public class Ucet//done
    {
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