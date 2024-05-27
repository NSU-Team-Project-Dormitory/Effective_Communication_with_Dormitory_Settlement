using System.Windows;
using System.Windows.Input;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;

namespace Presentation.View
{
    public partial class StudentInfoWindow : Window
    {
        public StudentInfoWindow(Student student)
        {
            InitializeComponent();
            DataContext = student;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Window_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
