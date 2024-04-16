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

            if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(region))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            // TODO: Проверка наличия данных, обработка исключений и другие проверки

            // Создаем нового студента
            var newAddress = new Address(street, city, region, postalCode, country); 

            // Добавляем студента в базу данных
            _addressRepository.Add(newAddress);

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
