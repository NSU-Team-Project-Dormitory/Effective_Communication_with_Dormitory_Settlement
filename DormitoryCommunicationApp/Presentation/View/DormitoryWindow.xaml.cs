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
using Data.Repositories.App.Role;
using Data.Repositories.Campus;
using Data.Repositories.SideInformation;
using Domain.Entities.App.Role;
using Domain.Entities.Campus;
using Domain.Entities.SideInformation;
using Domain.Repositories.App.Role;
using Domain.Repositories.Campus;
using Domain.Repositories.SideInformation;

namespace Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для DormitoryWindow.xaml
    /// </summary>
    /// 

    public partial class DormitoryWindow : Window
    {


        private IStudentRepository _studentRepository;
        private IAddressRepoisitory _addressRepository;
        private IBuildingRepository _dormitoryRepository;

        public static ListView AllAddressesView;
        public static ListView AllDormitoriesView;
        public static ListView AllStudentsView;

        private Building dormitory;



        public List<Student> Students { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Building> Dormitories { get; set; }

        public string DormitoryName { get; set; }
        public DormitoryWindow(Building dormitory)
        {
            InitializeComponent();
            this.dormitory = dormitory;
            DataContext = this;


            AllStudentsView = ViewAllStudents;


            _studentRepository = StudentRepository.GetRepository();
            _addressRepository = AddressRepository.GetRepository();
            _dormitoryRepository = BuildingRepository.GetRepository();

            DataContext = this;

            DormitoryName = dormitory.Name;
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
            Dormitories = _dormitoryRepository.GetAll();
            AllDormitoriesView.ItemsSource = null;
            AllDormitoriesView.Items.Clear();
            AllDormitoriesView.ItemsSource = Dormitories;
            AllDormitoriesView.Items.Refresh();
        }

        private void RefreshStudentTableWindow()
        {
            Students = _studentRepository.GetAll();

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Room.FloorID == null) {
                    Students[i] = null; break;
                }
            }
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



    }
}
