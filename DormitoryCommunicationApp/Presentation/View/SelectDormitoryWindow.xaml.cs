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
using Domain.Entities.Campus;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для SelectDormitoryWindow.xaml
    /// </summary>
    public partial class SelectDormitoryWindow : Window
    {
        public Building SelectedDormitory { get; private set; }

        public SelectDormitoryWindow(List<Building> dormitories)
        {
            InitializeComponent();

            // Заполняем список общежитий
            dormitoriesListBox.ItemsSource = dormitories;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (dormitoriesListBox.SelectedItem != null)
            {
                SelectedDormitory = (Building)dormitoriesListBox.SelectedItem;

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите общежитие.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            DialogResult=false;

        }
    }
}
