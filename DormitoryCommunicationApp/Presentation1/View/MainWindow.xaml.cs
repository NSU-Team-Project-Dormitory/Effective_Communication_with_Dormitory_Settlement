using System;
using System.Windows;
using System.Windows.Input;

namespace Presentation.View
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
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            } else if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }


        private void Database_Window_Click(object sender, RoutedEventArgs e)
        {  
            DataBaseManage dataBaseManage = new DataBaseManage();  
            dataBaseManage.Show();
            Hide();
        }

        

    }


}
