using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string display = "0";
        private string history = "";
        private bool ClearScreen = true;
        private bool decimalInserted = false;

        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void InputNumber(object sender, RoutedEventArgs e)
        {
            string num = (sender as Button).Name.ToString().Remove(0, 1);

            if (display[0] == '0' && num == "0") { return; }
            if (ClearScreen) { display = ""; }

            display += num;
            ClearScreen = false;
            Update();
        }

        private void InputDecimal(object sender, RoutedEventArgs e)
        {
            if (ClearScreen) { display = "0"; }
            if (decimalInserted) { return; }
            display += (sender as Button).Content;
            decimalInserted = true;
            ClearScreen = false;
            Update();
        }

        private void InputArithmatic(object sender, RoutedEventArgs e)
        {
            if (display == "") { return; }
            ClearScreen = true;
            decimalInserted = false;
            history = display + $" {(sender as Button).Content} ";
            Update();
        }

        private void EvaluateArithmatic(object sender, RoutedEventArgs e)
        {
            if(history == "") { return; }
            // a really scuffed way to allow for the repeated input of an operation
            // basically if yuou press '=' after putting in something like 3 + 3
            // it will ad 3 to the value of the operation (so history will say 6 + 3)

            string inputArithmatic;

            if (history.Contains("="))
            {
                string[] temp = history.Split(' '); // 3 + 20 =  ->  '3', '+', '20', '='
                temp[0] = display;
                inputArithmatic = String.Join(" ", temp);

                history = inputArithmatic;
            }
            else
            {
                inputArithmatic = history + display;
                history = inputArithmatic + " = ";
            }
            
            display = Calculate.CalculateString(inputArithmatic);
            ClearScreen = true;
            decimalInserted = false;
            Update();
        }

        private void FlipNum(object sender, RoutedEventArgs e)
        {
            if(display == "0") { return; }
            float tempNum = -1 * float.Parse(display);
            display = tempNum.ToString();
            Update();
        }

        private void InputClear(object sender, RoutedEventArgs e)
        {
            display = "0";
            history = "";
            ClearScreen = true;
            Update();
        }

        private void TrimNumberInput(object sender, RoutedEventArgs e)
        {
            if(display == "0") { return; }
            if(display.Length == 1) { 
                display = "0";
                ClearScreen = true;
            }
            else
            {
                display = display.Remove(display.Length - 1, 1);
            }
            Update();
        }

        private void Update()
        {
            InputScreen.Text = display;
            InputHistory.Text = history;
        }

    }
}
