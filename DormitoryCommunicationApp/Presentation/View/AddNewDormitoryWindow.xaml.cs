using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data.Repositories.Campus;
using Data.Repositories.SideInformation;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;
using Domain.Repositories.SideInformation;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewDormitoryWindow.xaml
    /// </summary>
    public partial class AddNewDormitoryWindow : Window
    {
        public string DormitoryName { get; private set; }


        private IBuildingRepository _BuildingRepository;
        public AddNewDormitoryWindow(IBuildingRepository BuildingRepoisitory)
        {
            InitializeComponent();
            _BuildingRepository = BuildingRepository.GetRepository();
        }
        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Проверка наличия данных, обработка исключений и другие проверки

            // Получаем данные о студенте из TextBox


            string name = dormitoryName.Text;

            Address address = new Address();
            string street = dormitoryAddress.Text;
            address.Street = street;



            int number;
            if (!int.TryParse(dormitoryFloorCount.Text, out number))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string contactNumber = dormitoryContactInfo.Text;
            var contact = new Contact();
            contact.PhoneNumber = contactNumber;
            contact.Email = " ";


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(street) || number == null || string.IsNullOrWhiteSpace(contactNumber))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newBuilding = new Building(name, address, contact, number);

            // Добавляем студента в базу данных
            _BuildingRepository.Add(newBuilding);

            // Закрываем окно добавления студента
            Close();
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
    }
}
