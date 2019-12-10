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

namespace CheckMethod
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static List<TextBox> xS = new List<TextBox>();
        private static List<double> xSAfterAverageMinus = new List<double>();

        private void NecessarilyCountOfTextBoxes(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbxCount.Text, out int x))
            {
                for (int i = 0; i < x; i++)
                {
                    TextBox tbx = new TextBox();
                    tbx.Margin = new Thickness(20, 5, 20, 5);
                    tbx.Height = 20;
                    tbx.Width = 70;
                    tbx.Name = "tbxX_" + i.ToString();
                    tbx.HorizontalAlignment = HorizontalAlignment.Center;
                    xS.Add(tbx);
                    secondSp.Children.Add(tbx);
                }
                tbxCount.IsEnabled = false;
                ConfirmCount_Btn.IsEnabled = false;
            }
            else if (x > 10 && x < 3)
            {
                MessageBox.Show("Введите цифру не меньше 3 и не больше 10!");
                tbxCount.Text = "";
            }
            else if (tbxCount.Text == "")
            {
                MessageBox.Show("Введите цифру не меньше 3 и не больше 10!");
            }
            else
            {
                MessageBox.Show("Вы ввели неправильные данные!");
                tbxCount.Text = "";
            }
            Button Confirm_xS_Btn = new Button();
            Confirm_xS_Btn.Content = "Принять";
            Confirm_xS_Btn.Height = 20;
            Confirm_xS_Btn.Width = 50;
            Confirm_xS_Btn.Click += Confirm_xS_Click;
            secondSp.Children.Add(Confirm_xS_Btn);
        }
        private void Confirm_xS_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in xS)
            {
                if (item.Text.Contains("."))
                {
                    item.Text=item.Text.Replace(".", ",");
                }
            }

            var res = xS.Sum(w => Double.Parse(w.Text));
            res = res / Convert.ToInt32(tbxCount.Text);

            for (int i = 0; i < xS.Count; i++)
            {
                string s = xS[i].Text;
                xSAfterAverageMinus.Add(Math.Abs(res - Double.Parse(s)));
                xSAfterAverageMinus[i] = Math.Pow(xSAfterAverageMinus[i], 2);
            }

            var sumOfPow = xSAfterAverageMinus.Sum();
            var res2 = sumOfPow / (Convert.ToInt32(tbxCount.Text) * (Convert.ToInt32(tbxCount.Text) - 1));
            double tn = 0;
            if (Convert.ToInt32(tbxCount.Text) == 3)
            {
                tn = 4.30;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 4)
            {
                tn = 3.18;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 5)
            {
                tn = 2.78;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 6)
            {
                tn = 2.57;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 7)
            {
                tn = 2.45;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 8)
            {
                tn = 2.36;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 9)
            {
                tn = 2.31;
            }
            else if (Convert.ToInt32(tbxCount.Text) == 10)
            {
                tn = 2.26;
            }
            res2 = Math.Sqrt(res2);
            double res3 = res2 * tn;
            Label label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Center;

            label.Content = "Final Result = ( " + res + " ± " + res3 + " )";
            secondSp.Children.Add(label);
            MessageBox.Show(label.Content.ToString());
        }
    }
}
