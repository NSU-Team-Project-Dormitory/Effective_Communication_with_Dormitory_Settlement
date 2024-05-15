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

        
    }
}
