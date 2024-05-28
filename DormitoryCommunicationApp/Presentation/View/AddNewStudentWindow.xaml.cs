using System;
using System.Windows;
using Data.Repositories.App.Role;
using System.Windows.Input;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;

namespace Presentation.View
{
    public partial class AddNewStudentWindow : Window
    {
        public AddNewStudentWindow()
        {
            InitializeComponent();
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Window_Click(Object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            // Собираем данные из полей
            string firstName = studentFirstName.Text;
            string secondName = studentSecondName.Text;
            string patronymic = studentPatronymic.Text;
            string faculty = studentFaculty.Text;
            int studyGroup = 0;
            int contactNumber;

            // Валидация контактного номера
            if (!int.TryParse(studentContactNumber.Text, out contactNumber))
            {
                MessageBox.Show("Пожалуйста, введите корректный контактный номер.");
                return;
            }
            if (!int.TryParse(studentStudyGroup.Text, out contactNumber))
            {
                MessageBox.Show("Пожалуйста, введите корректный контактный номер.");
                return;
            }

            // Создаем объект StudentGroup (может потребоваться изменить этот код в зависимости от вашей реализации)
            //StudentGroup group = new StudentGroup(1, "YES");

            StudentGroup studentGroup = new StudentGroup (studyGroup, "Faculcy");

            // Создаем объект Student
            Student newStudent = new Student
            {
                FirstName = firstName,
                SecondName = secondName,
                PatronymicName = patronymic,
                //Faculty = faculty,
                ContactNumber = contactNumber,
                StudentGroup = studentGroup
            };

            // Вызываем репозиторий для добавления студента
            IStudentRepository studentRepository = StudentRepository.GetRepository();
            bool success = studentRepository.Add(newStudent);

            if (success)
            {
                MessageBox.Show("Студент успешно добавлен!");
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении студента. Возможно, студент с таким контактным номером уже существует.");
            }
        }
    }
}
