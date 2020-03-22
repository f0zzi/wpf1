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

namespace wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double oper1 = 0;
        double oper2 = 0;
        string operation = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button tmp = (sender as Button);
            if (tmp.Content.ToString() == "Enter")
                tbScreen.AppendText("\n");
            else if (tmp.Content.ToString() == ".")
            {
                if (!tbScreen.Text.Contains("."))
                    tbScreen.AppendText(tmp.Content.ToString());
            }
            else
            {
                if (tbScreen.Text == "0")
                    tbScreen.Text = "";
                tbScreen.AppendText((sender as Button).Content.ToString());
            }
        }

        private void Switch_sign(object sender, RoutedEventArgs e)
        {
            string tmp = tbScreen.Text;
            if (tmp != "0")
                tbScreen.Text = (-(Convert.ToDouble(tmp))).ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (tbScreen.Text != "0")
                tbScreen.Undo();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            oper1 = oper2 = 0;
            operation = null;
            tbScreen.Text = "0";
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (operation == null)
            {
                oper1 = Convert.ToDouble(tbScreen.Text);
                operation = (sender as Button).Content.ToString();
            }
            else
            {

            }
        }
        private double GetResult(double oper1, double oper2, string operation)
        {
            double result = 0;
            switch(operation)
            {
                case "+":
                    result = oper1 + oper2;
                    break;
                case "-":
                    result = oper1 + oper2;
                    break;
                case "*":
                    result = oper1 * oper2;
                    break;
                case "/":
                    if (oper2 == 0)
                        return 0;
                    result = oper1 / oper2;
                    break;
            }
            return result;
        }
    }
}
