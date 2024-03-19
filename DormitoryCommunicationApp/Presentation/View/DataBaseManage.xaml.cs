
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Presentation.ViewModel;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для DataBaseManage.xaml
    /// </summary>
    public partial class DataBaseManage : Window
    {
        public DataBaseManage()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }


        private void Hide_Window_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Window_Click(Object sender, RoutedEventArgs e)
        {
           Environment.Exit(0);

        }

        private void Normalize_Window_Clock(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Home_Window_Click(object sender, RoutedEventArgs e)
        {
            
            
            MainWindow mainWindow = new MainWindow(); 
            mainWindow.Show();
            Hide();

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
