using System;
using System.Windows;
using System.Windows.Input;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Repositories.App.Role;
using Domain.Repositories.Campus;

namespace Presentation.View
{
    public partial class FindStudentWindow : Window
    {
        private IStudentRepository _studentRepository;

        public FindStudentWindow(IStudentRepository studentRepository)
        {
            InitializeComponent();
            _studentRepository = studentRepository;
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

        private void FindStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = studentFirstName.Text;
            string lastName = studentLastName.Text;
            string patronymic = studentPatronymic.Text;

            Student student = _studentRepository.Find(firstName, lastName, patronymic);

            if (student != null)
            {
                ShowStudentInfo(student);
            }
            else
            {
                MessageBox.Show("Студент не найден.");
            }
        }

        private void ShowStudentInfo(Student student)
        {
            var studentInfoWindow = new StudentInfoWindow(student);
            studentInfoWindow.Show();
        }
    }
}
