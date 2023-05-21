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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDigitButtonClicked(object sender, RoutedEventArgs e)
        {
            if(sender is not Button button)
                return;
            if(button.Content is not string digitString)
                return;
            var isNumber = int.TryParse(digitString, out var digit);
            if(isNumber && digit is >= 0 and <= 9)
                Display2.Text += digitString;
            if(Display2.Text.Length>20)
                Display2.Text = Display2.Text.Substring(0, Display2.Text.Length - 1);
        }

        private void OnDeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if(Display2.Text.Length == 0)
            {
                if (Display1.Text.Length != 0)
                {
                    Display2.Text = Display1.Text;
                    Display1.Text = "";
                }else
                {
                    return;
                }
            } 
            Display2.Text = Display2.Text.Substring(0, Display2.Text.Length - 1);
        }

        private void OnOperatorButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;
            var operatorString = button.Content as string;               
            double result = 0;

            if (Display2.Text.Length!=0)
            {
                if (Display1.Text.Length == 0)
                {
                    Display1.Text = Display2.Text;
                    if(operatorString!= "=") { 
                    Display1.Text += operatorString;
                    }
                    Display2.Text = "";

                }
                else {
                    double firstNumber = double.Parse(Display1.Text.Substring(0, Display1.Text.Length - 1));
                    string op = Display1.Text.Substring(Display1.Text.Length - 1, 1);
                    double secondNumber = double.Parse(Display2.Text);
                    switch(op)
                    {
                        case "x":
                            result = firstNumber*secondNumber; 
                            break;
                        case "-":
                            result = firstNumber - secondNumber;
                            break;
                        case "+":
                            result = firstNumber + secondNumber;
                            break;
                        case "÷":
                            result = firstNumber / secondNumber;
                            break;
                        
                    }
                    Display2.Text = "";
                    if (operatorString!="=")
                        Display1.Text = result.ToString()+operatorString;
                    else
                    {
                        Display1.Text = "";
                        Display2.Text = result.ToString();
                    }
                    
                }
                
                

            }
            else
            {
                
                Display2.Text = "";
            }
        }
    }
}
