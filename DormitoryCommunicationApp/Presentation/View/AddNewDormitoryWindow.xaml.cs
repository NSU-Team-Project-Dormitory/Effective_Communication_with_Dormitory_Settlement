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

        private Address _address;
        public string DormitoryName { get; private set; }


        private IAddressRepoisitory _addressRepository;

        private IBuildingRepository _buildingRepository;
        public AddNewDormitoryWindow(IBuildingRepository BuildingRepoisitory)
        {
            InitializeComponent();
            _addressRepository = AddressRepository.GetRepository();
            _buildingRepository = BuildingRepository.GetRepository();
        }
        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {

            string name = dormitoryName.Text;
            

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


            if (string.IsNullOrWhiteSpace(name)  || number == null || string.IsNullOrWhiteSpace(contactNumber))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newBuilding = new Building(name, _address, contact, number);

            
            _buildingRepository.Add(newBuilding);

            Close();
        }

        private void Add_AddressButton_CLick(object sender, RoutedEventArgs e)
        {
            AddNewAddressWindow addNewAddressWindow = new AddNewAddressWindow(_addressRepository);
            addNewAddressWindow.ShowDialog();

            _address = addNewAddressWindow.SelectedAddress;

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
