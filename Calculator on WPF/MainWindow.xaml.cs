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
            if (textLabel_1.Text.Length == 35) { textLabel_1.FontSize = 13; }

            if (isSolved == true)
            {
                textLabel_1.Text = "";
                isSolved = false;
            }

            // Мы берем объект, который идет на основе класса RoutedEventArgs, преобразовываем его к классу
            // button. Далее берется OriginalSource и его Content. И всё это присваивается к переменной enteredButtons.
            string enteredButton = (string)((Button)e.OriginalSource).Content;

            if (enteredButton == "Clear") 
                textLabel_1.Text = ""; 
            else if (enteredButton == "=")
            {
                // Метод Compute отвечает за преобразование текста в математическое действие
                string value = new DataTable().Compute(textLabel_1.Text, null).ToString();
                textLabel_1.Text += ("\n = " + value);

                isSolved = true;
            }
            else  
                textLabel_1.Text += enteredButton; 
        }


    }
}
