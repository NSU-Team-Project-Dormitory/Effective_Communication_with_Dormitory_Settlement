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

namespace CampusProjectWithWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button) el).Click += Button_Click;
                }
            }
        }

        private string chooseToStringParser(string input)
        {
            if (input == "5")
            {
                return "Пятое Общежитие";
            }

            switch (input)
            {
                case "1А":
                    return "Общежитие 1А";
                case "1Б":
                    return "Общежитие 1Б";
                case "4":
                    return "Четвертое общежитие";
                case "5":
                    return "Пятое общежитие";
                case "6":
                    return "Шестое общежитие";
                case "7":
                    return "Седьмое общежитие";
                case "8/1":
                    return "Общежитие 8/1";
                case "8/2":
                    return "Общежитие 8/2";
                case "9":
                    return "Девятое общежитие";
                case "10":
                    return "Десятое общежитие";
                default:
                    return "Нет такого общежития";

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedDormintory = (string)((Button)e.OriginalSource).Content;

            textLabel.Text = selectedDormintory;


            DormitoryWindow dormitoryWindow = new DormitoryWindow();
            dormitoryWindow.Show();

            dormitoryWindow.MainTextBlock.Text = chooseToStringParser(selectedDormintory);



        }
    }
}
