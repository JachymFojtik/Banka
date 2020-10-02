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
        public MainWindow()
        {
            InitializeComponent();
            Sporici s1 = new Sporici();
            Sporici s2 = new Sporici(500);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public abstract class Ucet
    {
        public decimal Zustatek { get; set; }

        //public Ucet(decimal z)
        //{
        //    Zustatek += z;
        //}
        public void Pridat(string s)
        {
            try
            {
                int i = int.Parse(s);
                Zustatek += i;
            }
            catch (Exception)
            {

            }
        }
    }
    public class Sporici : Ucet
    {
        public decimal Zustatek { get; set; }
        public Sporici(decimal z)
        {

        }
        public Sporici()
        {
            Zustatek = 0;
        }
    }

}