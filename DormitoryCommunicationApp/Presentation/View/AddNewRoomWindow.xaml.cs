using Data.Repositories.Campus;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.Campus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewRoomWindow.xaml
    /// </summary>
    public partial class AddNewRoomWindow : Window
    {
        private Building dormitory;
        public string DormitoryName { get; set; }

        private IRoomRepository _roomRepository;
        private IBuildingRepository _buildingRepository;

        public AddNewRoomWindow(Building dormitory)
        {
            InitializeComponent();
            _roomRepository = RoomRepository.GetRepository();
            this.dormitory = dormitory;
            DataContext = this;
            DormitoryName = dormitory.Name;
        }
        private void AddRoomButton_Click(object sender, RoutedEventArgs e)
        {
            /*// TODO: Проверка наличия данных, обработка исключений и другие проверки

            // Получаем данные о комнате из TextBox
            string floor = roomFloor.Text;
            string number = roomNumber.Text;
            string capacityTxt = roomCapacity.Text;

            if (string.IsNullOrWhiteSpace(floor) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(capacityTxt))
            {
                MessageBox.Show("Please enter all info correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //int floor = 0;
            int capacity = 0;

            *//*
            if (!Int32.TryParse(floorTxt, out floor)){
                MessageBox.Show("Please enter all info correct. Floor is a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*//*

            if (!Int32.TryParse(capacityTxt, out capacity))
            {
                MessageBox.Show("Please enter all info correct. Capacity is a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            //var room = new Room(number, capacity, floor);


            _roomRepository.Add(number, capacity, new Floor(number, dormitory));*/

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