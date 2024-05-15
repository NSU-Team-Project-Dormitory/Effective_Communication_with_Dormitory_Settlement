
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Data.Repositories.App.Role;
using Data.Repositories.Campus;
using Data.Repositories.SideInformation;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;
using Domain.Repositories.Campus;
using Domain.Repositories.SideInformation;
using Presentation.ViewModel;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для DataBaseManage.xaml
    /// </summary>
    public partial class DataBaseManage : Window
    {
        private IStudentRepository _studentRepository;
        private IAddressRepoisitory _addressRepository;
        private IBuildingRepository _buildingRepository;

        public static ListView AllAddressesView;
        public static ListView AllDormitoriesView;
        public static ListView AllStudentsView;


        public List<Student> Students { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Building> Dormitories { get; set; }   
        public DataBaseManage()
        {
            InitializeComponent();

            AllAddressesView = ViewAllAddresses;
            AllStudentsView = ViewAllStudents;
            AllDormitoriesView = ViewAllDormitories;


            _studentRepository = StudentRepository.GetRepository();
            _addressRepository = AddressRepository.GetRepository();
            _buildingRepository = BuildingRepository.GetRepository();
            RefreshAllTablesWindow();




       
            DataContext = this;
        }

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewAddressWindow = new AddNewAddressWindow(_addressRepository);
            addNewAddressWindow.ShowDialog();

            RefreshAddressTableWindow();
        }

        private void AddStudentButton_Click(Object sender, RoutedEventArgs e)
        {
            var addNewStudentWindow = new AddNewStudentWindow();
            addNewStudentWindow.ShowDialog();

            RefreshAddressTableWindow();
        }

        private void AddDormitoryButton_Click(Object sender, RoutedEventArgs e)
        {
            var addNewDormitoryWindow = new AddNewDormitoryWindow(_buildingRepository);
            addNewDormitoryWindow.ShowDialog();

            RefreshAddressTableWindow();
        }

        private void RefreshAddressTableWindow()
        {
            Addresses = _addressRepository.GetAll();
            AllAddressesView.ItemsSource = null;
            AllAddressesView.Items.Clear();
            AllAddressesView.ItemsSource = Addresses;
            AllAddressesView.Items.Refresh();
        }

        private void RefreshDormitoryTableWindow()
        {
            Dormitories = _buildingRepository.GetAll();
            AllDormitoriesView.ItemsSource = null;
            AllDormitoriesView.Items.Clear();
            AllDormitoriesView.ItemsSource = Dormitories;
            AllDormitoriesView.Items.Refresh();
        }

        private void RefreshStudentTableWindow()
        {
            Students = _studentRepository.GetAll();
            AllStudentsView.ItemsSource = null;
            AllStudentsView.Items.Clear();
            AllStudentsView.ItemsSource = Students;
            AllStudentsView.Items.Refresh();
        }

        private void RefreshAllTablesWindow()
        {
            RefreshAddressTableWindow();
            RefreshDormitoryTableWindow();
            RefreshStudentTableWindow();
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

        private void ListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что кликнуто правой кнопкой мыши
            if (e.RightButton == MouseButtonState.Pressed)
            {
                // Получаем элемент, по которому кликнули
                ListViewItem item = GetListViewItem(sender as ListView, e.GetPosition(sender as ListView));
                if (item != null)
                {
                    // Создаем контекстное меню
                    ContextMenu contextMenu = new ContextMenu();

                    // Создаем пункт меню для удаления студента
                    MenuItem deleteMenuItem = new MenuItem();
                    deleteMenuItem.Header = "Delete";
                    deleteMenuItem.Click += DeleteMenuItem_Click;

                    // Добавляем пункт меню в контекстное меню
                    contextMenu.Items.Add(deleteMenuItem);

                    // Показываем контекстное меню
                    item.ContextMenu = contextMenu;
                }
            }
        }

        private void ListView_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // Получаем ListView
            ListView listView = sender as ListView;

            // Получаем элемент, на котором был клик
            ListViewItem item = GetListViewItem(listView, Mouse.GetPosition(listView));

            if (item != null)
            {
                // Создаем контекстное меню
                ContextMenu contextMenu = new ContextMenu();

                // Создаем пункт меню для удаления студента
                MenuItem deleteMenuItem = new MenuItem();
                deleteMenuItem.Header = "Delete Student";
                deleteMenuItem.Click += DeleteMenuItem_Click;

                // Добавляем пункт меню в контекстное меню
                contextMenu.Items.Add(deleteMenuItem);

                // Устанавливаем контекстное меню для элемента ListView
                listView.ContextMenu = contextMenu;
            }
            else
            {
                // Если кликнули за пределами элементов, скрываем контекстное меню
                listView.ContextMenu = null;
            }
        }

        private ListViewItem GetListViewItem(ListView listView, Point position)
        {
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(listView, position);
            if (hitTestResult != null)
            {
                DependencyObject obj = hitTestResult.VisualHit;
                while (obj != null && obj != listView)
                {
                    if (obj is ListViewItem)
                    {
                        return (ListViewItem)obj;
                    }
                    obj = VisualTreeHelper.GetParent(obj);
                }
            }
            return null;
        }


        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент в списке
            Address selectedAddress = (Address)ViewAllAddresses.SelectedItem;

            // Удаляем студента из базы данных
            _addressRepository.Delete(selectedAddress);

            // Обновляем список студентов
            RefreshAddressTableWindow();
        }


    }
}
