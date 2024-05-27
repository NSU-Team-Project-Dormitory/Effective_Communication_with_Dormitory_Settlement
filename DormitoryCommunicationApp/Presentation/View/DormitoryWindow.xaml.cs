using System.Windows;
using System.Windows.Input;
using Domain.Entities.Campus;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для DormitoryWindow.xaml
    /// </summary>
    public partial class DormitoryWindow : Window
    {
        private Building dormitory;
        public string DormitoryName { get; set; }

        public DormitoryWindow(Building dormitory)
        {
            InitializeComponent();
            this.dormitory = dormitory;
            DataContext = this;
            DormitoryName = dormitory.Name;
        }

        private void Close_Window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void AddNewRoomButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewRoomWindow addNewRoomWindow = new AddNewRoomWindow(dormitory);
            addNewRoomWindow.Show();
        }
    }
}
