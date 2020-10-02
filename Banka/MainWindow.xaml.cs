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
        public string vyber;
        public MainWindow()
        {
            InitializeComponent();
            Sporici s1 = new Sporici("Jachym");
            Sporici s2 = new Sporici("Petr", 500);
            lbUcty.Items.Add("Jachym");
            lbUcty.Items.Add(s2.Jmeno);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void LbUcty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vyber = lbUcty.SelectedItem.ToString();
            lNazev.Content = $"Název účtu: {vyber}";
        }

        private void bPridat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bCas_Click(object sender, RoutedEventArgs e)
        {

        }



        private void bVybrat_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Ucet
    {
        public decimal Zustatek { get; set; }
        public string Jmeno { get; set; }

        public void Pridat(string s)
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
    }
}