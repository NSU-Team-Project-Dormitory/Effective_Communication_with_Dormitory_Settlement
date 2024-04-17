using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Data.Repositories.App.Role;
using Data.Repositories.Campus;
using Data.Repositories.SideInformation;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;
using Domain.Repositories.Campus;
using Domain.Repositories.SideInformation;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ItemsControl AllDormitoriesView;

        private IBuildingRepository _dormitoryRepository;

        public List<Building> Dormitories { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            AllDormitoriesView = ViewAllDormitories;


            _dormitoryRepository = BuildingRepository.GetRepository();

            RefreshDormitories();

            DataContext = this;

        }

        private void RefreshDormitories()
        {
            Dormitories = _dormitoryRepository.GetAll();
            AllDormitoriesView.ItemsSource = null;
            AllDormitoriesView.Items.Clear();
            AllDormitoriesView.ItemsSource = Dormitories;
            AllDormitoriesView.Items.Refresh();
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

        private void Add_DormitoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewDormitoryWindow addNewDormitoryWindow = new AddNewDormitoryWindow(_dormitoryRepository);
            addNewDormitoryWindow.ShowDialog();

            RefreshDormitories();
        }



        private void DeleteDormitoryButton_Click(object sender, RoutedEventArgs e)
        {

            // Получаем имя общежития для удаления
            string dormitoryNameToDelete = "1234";

            Building dormitoryToDelete = Dormitories.FirstOrDefault(d => d.Name == dormitoryNameToDelete);


                // Удаляем студента из базы данных
            _dormitoryRepository.Delete(dormitoryToDelete);

                // Обновляем список студентов
            RefreshDormitories();

        }
    }


}
