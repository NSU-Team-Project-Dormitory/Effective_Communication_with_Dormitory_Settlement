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
            DataContext = new StudentViewModel(student); 
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

    // ViewModel для студента
    public class StudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public StudentViewModel(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.SecondName;
            Patronymic = student.PatronymicName;
            Login = student.Login;
            Gender = student.Sex;
            BirthDate = student.DateOfBirth.ToString("dd/MM/yyyy");
            PhoneNumber = student.ContactNumber.ToString();
        }
    }
}
