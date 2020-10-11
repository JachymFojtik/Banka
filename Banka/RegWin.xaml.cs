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
using System.Windows.Shapes;

namespace Banka
{
    /// <summary>
    /// Interaction logic for RegWin.xaml
    /// </summary>
    public partial class RegWin : Window
    {
        public List<string> Ucty = new List<string>();
        public RegWin()
        {
            InitializeComponent();
            try
            {
                string[] f = File.ReadAllLines("ucty.txt");
                foreach (var item in f)
                {
                    Ucty.Add(item);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Databáze s účty nenalezena");
            }
            List<string> Typy = new List<string> { "Spořící", "Úvěrový", "Studentský" };
            foreach (var item in Typy)
            {
                cbTyp.Items.Add(item);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int vklad;
            bool vklad_JeInt = int.TryParse(tbVklad.Text, out vklad);
            if (vklad_JeInt)
            {
                string s = $"{cbTyp.SelectedItem}-{tbJmeno.Text}-{vklad}";
                Ucty.Add(s);
                File.WriteAllLines("ucty.txt", Ucty);
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Vklad je ve ve špatném formátu");
            }

        }
    }
}
