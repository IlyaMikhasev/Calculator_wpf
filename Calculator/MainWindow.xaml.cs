using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        myCalc _myCalc;
        string _input = string.Empty;
        double _num1 = 0, _num2 = 0;
        char _sym ;
        public MainWindow()
        {
            InitializeComponent();

            _myCalc = new myCalc();
        }
        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            var sym = ((Button)sender).Content.ToString();
            if (sym != "C")
                texbBoxInput.Text += sym;
            else
            {
                delLastSym();
            }
        }
        private void btn_event_click(object sender, RoutedEventArgs e)
        {
            if (_sym == '\0')
            {
                if (texbBoxInput.Text[texbBoxInput.Text.Length - 1] != _sym)
                    _sym = char.Parse(((Button)sender).Content.ToString());
                else
                {
                    delLastSym();
                    _sym = char.Parse(((Button)sender).Content.ToString());
                }
                /*texbBoxInput.Text += ((Button)sender).Content.ToString();*/
            }
            else
            {
                _sym = char.Parse(((Button)sender).Content.ToString());
                b_equals_Click(sender, e);
            }
            texbBoxInput.Text += ((Button)sender).Content.ToString();
        }
        private void delLastSym() {
            _input = texbBoxInput.Text;
            texbBoxInput.Text = _input.Remove(_input.Length - 1);
        }
        private void b_equals_Click(object sender, RoutedEventArgs e)
        {
            
            texbBoxInput.Text=txtblock_output.Text;
        }
        private void serchNUMBER()
        {
            var numbers = _input.Split(_sym);
            if (numbers.Length == 2 && numbers[1].ToString()!="")
            {
                _num1 = double.Parse(numbers[0].ToString());
                _num2 = double.Parse(numbers[1].ToString());
                if (_num2 == 0)
                {
                    delLastSym();
                    return;
                }
                txtblock_output.Text = _myCalc.funcCalc(_sym, _num1, _num2).ToString();
            }
        }

        private void texbBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            _input = texbBoxInput.Text;
            serchNUMBER();
        }

        private void texbBoxInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!texbBoxInput.Text.Contains(".")
               && texbBoxInput.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
