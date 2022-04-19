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

namespace Genshin_Wish_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Data_Final.SelectedDate = DateTime.Today;
            Total.Content = 0;
        }

        int primogem_total = 0, total_dias, total_meses, total_Abyss = 0;
        float total_mesesf;

        private void Cliquei(object sender, RoutedEventArgs e)
        {
            Quantidade_Atual.Text = string.Empty;
        }

        private void Quantidade_Atual_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Descliquei(object sender, RoutedEventArgs e)
        {
            if(Quantidade_Atual.Text == string.Empty)
            {
                Quantidade_Atual.Text = "0";
            }
        }

        private void Bencao_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Passe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            primogem_total = 0;
            total_Abyss = 0;
            TimeSpan date = Convert.ToDateTime(Data_Final.Text) - Convert.ToDateTime(DateTime.Today);
            total_dias = date.Days + 1;
            total_mesesf = date.Days / 30;
            Math.Ceiling(total_mesesf);
            total_meses = (int)total_mesesf;

            if (Bencao.IsChecked == true)
            {
                primogem_total += (total_dias * 90) + (total_meses * 300);
            }
            if (Passe.IsChecked == true)
            {
                primogem_total += (4 * 160) + (680 * (total_meses / 2));
            }
            total_Abyss += Abyss_9.SelectedIndex + Abyss_10.SelectedIndex + Abyss_11.SelectedIndex + Abyss_12.SelectedIndex;
            if (total_meses > 0) { total_Abyss = total_Abyss * total_meses * 2; }
            primogem_total += int.Parse(Quantidade_Atual.Text);
            primogem_total += (60 * total_dias) + (50 * total_Abyss);
            Total.Content = (primogem_total / 160);
        }        
    }
}
