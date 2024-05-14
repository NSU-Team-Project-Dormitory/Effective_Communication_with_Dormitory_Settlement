using Data.Repositories.SideInformation;
using Domain.Entities.SideInformation;
using Domain.Repositories.SideInformation;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewAddressWindow.xaml
    /// </summary>
    /// 
    
    public partial class AddNewAddressWindow : Window
    {
        private readonly IAddressRepoisitory _addressRepository;

        public Address SelectedAddress { get; private set; }
        public AddNewAddressWindow(IAddressRepoisitory addressRepoisitory)
        {
            InitializeComponent();
            _addressRepository = AddressRepository.GetRepository();
        }
        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Проверка наличия данных, обработка исключений и другие проверки

            // Получаем данные о студенте из TextBox
            string street = addressStreet.Text;
            string city = addressCity.Text;
            string postalCode = addressPostalCode.Text;
            string country = addressCountry.Text;
            string region = addressRegion.Text;
            string houseNumber = addressHouseNumber.Text;

            if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(region))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            var newAddress = new Address(street, houseNumber, city, region, postalCode, country); 




            SelectedAddress = new Address
            {
                HouseNumber = newAddress.HouseNumber,
                Street = newAddress.Street,
                City = newAddress.City,
                PostalCode = newAddress.PostalCode,
                Country = newAddress.Country,
                Region = newAddress.Region
            };


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
