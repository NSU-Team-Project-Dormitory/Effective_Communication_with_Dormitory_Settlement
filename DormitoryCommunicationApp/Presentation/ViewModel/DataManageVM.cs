
using System.ComponentModel;
using System.Windows.Input;
using Data.Repositories.App.Role;
using Domain.Entities.App.Role;
using Domain.Repositories.App.Role;
using Presentation.View;
using System;
using System.Collections.Generic;
using System.Windows;
using Data;
using Domain.Entities.Campus;
using Data.Repositories.Campus;



namespace Presentation.ViewModel
{

    public class DataManageVM : INotifyPropertyChanged
    {



        private List<Student> students = StudentRepository.GetAll();
        public List<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                NotifyPropertyChanged("AllStudents");
            }
        }


        private List<Building> dormitories = BuildingRepository.GetAll();
        public List<Building> Dormitories
        {
            get { return dormitories; }
            set
            {
                dormitories = value;
                NotifyPropertyChanged("AllDormitories");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #region  METHODS TO OPEN WINDOW


        private void OpenAddStudentWindowMethod()
        {
            AddNewStudentWindow newStudentWindow = new()
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            newStudentWindow.ShowDialog();
        }

        private void OpenEditStudentWindowMethod()
        {
            EditStudentWindow editStudentWindow = new EditStudentWindow();
            editStudentWindow.Owner = Application.Current.MainWindow;
            editStudentWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editStudentWindow.ShowDialog();
        }

        private void OpenAddDormitoryWindowMethod()
        {
            AddNewDormitoryWindow newDormitoryWindow = new()
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            newDormitoryWindow.ShowDialog();
        }

        private void OpenEditDormitoryWindowMethod()
        {
            EditDormitoryWindow editDormitoryWindow = new EditDormitoryWindow();

            editDormitoryWindow.Owner = Application.Current.MainWindow;
            editDormitoryWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editDormitoryWindow.ShowDialog();
        }

        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewStudentWindow;

        public RelayCommand OpenAddNewStudentWindow
        {
            get { 
                return openAddNewStudentWindow ?? new RelayCommand(obj =>
                {
                    OpenAddStudentWindowMethod();
                }
                ); 
            } 
            
        }

        private RelayCommand openAddNewDormitoryWindow;

        public RelayCommand OpenAddNewDormitoryWindow
        {
            get
            {
                return openAddNewDormitoryWindow ?? new RelayCommand(obj =>
                {
                    OpenAddDormitoryWindowMethod();
                }
                );
            }

        }

        #endregion
    }
}

