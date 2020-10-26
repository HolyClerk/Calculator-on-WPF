using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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

namespace Calculator_on_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isSolved = false;

        public MainWindow()
        {
            InitializeComponent();


            foreach (UIElement element in MainContainer.Children)
            {
                if (element is Button)
                {
                    ((Button) element).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            /*
             * Мы берем объект, который идет на основе класса RoutedEventArgs, преобразовываем его к классу
             * button. Далее берется OriginalSource и его Content. И всё это присваивается к переменной enteredButtons.
             * За математические действия калькулятора отвечает метод Compute, который преобразовывает строку в решение
             */
            string enteredButton = (string)((Button)e.OriginalSource).Content;
            string[] mathSymbols = new string[4]
                {
                    "+", "-", "/", "*"
                };

            // Проверка на длинну и решеный пример
            if (textLabel_1.Text.Length == 35) { textLabel_1.FontSize = 13; }

            if (isSolved == true)
            {
                textLabel_1.Text = "";
                isSolved = false;
            }

            // Проверка нажатий кнопок
            if (enteredButton == "Clear")
            {
                textLabel_1.Text = "";
            }
            else if (enteredButton == "=")
            {
                string value = new DataTable().Compute(textLabel_1.Text, null).ToString();

                textLabel_1.Text += ("\n = " + value);
                isSolved = true;
            }
            else
            {
                // int textLength = textLabel_1.Text.Length;
                int mathSymbolsLength = mathSymbols.Length;

                // string converted = textLabel_1.Text.ToString();
                string text = enteredButton;

                // if (converted[textLength].ToString() == converted[textLength-1].ToString())
                for (int i = 0; i < mathSymbolsLength; i++)
                {
                    if (enteredButton == mathSymbols[i])
                        text = " " + enteredButton + " ";
                }

                textLabel_1.Text += text;
            }
        }
    }
}
