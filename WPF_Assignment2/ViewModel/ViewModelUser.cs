using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{

    public class ViewModelUser : ViewModelBase
    {
        PersonnelBusinessObject personnel;
        ObservableCollection<Model.User> _Employee;
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }

        public ObservableCollection<Model.User> Employee
        {
            get
            {
                _Employee = new ObservableCollection<Model.User>(personnel.GetEmployees());
                return _Employee;
            }
        }

        public ViewModelUser()
        {
            personnel = new PersonnelBusinessObject();
            CancelCommand = new RelayCommand(DoCancel);
            SaveCommand = new RelayCommand(DoSave);
            AddUserCommand = new RelayCommand(AddUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
            personnel.EmployeeChanged += new EventHandler(personnel_EmployeeChanged);
            UpdateBindingGroup = new BindingGroup { Name = "Group1" };
            DataGridCollection = CollectionViewSource.GetDefaultView(Employee);
            DataGridCollection.Filter = new Predicate<object>(Filter);
        }

        void DoCancel(object param)
        {
            UpdateBindingGroup.CancelEdit();
            if (SelectedIndex == -1)    //This only closes if new - just to show you how CancelEdit returns old values to bindings
                SelectedEmployee = null;
        }

        void DoSave(object param)
        {
            UpdateBindingGroup.CommitEdit();
            var employee = SelectedEmployee as Model.User;
            if (SelectedIndex == -1)
            {
                personnel.AddEmployee(employee);
                OnPropertyChanged("Employee"); // Update the list from the data source
            }
            else
                personnel.UpdateEmployee(employee);

            SelectedEmployee = null;
        }

        void AddUser(object parameter)
        {
            SelectedEmployee = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var employee = new Model.User();
            SelectedEmployee = employee;
        }

        void DeleteUser(object parameter)
        {
            var employee = SelectedEmployee as Model.User;
            if (SelectedIndex != -1)
            {
                personnel.DeleteEmployee(employee);
                OnPropertyChanged("Employee"); // Update the list from the data source
            }
            else
                SelectedEmployee = null; // Simply discard the new object
        }
        ObservableCollection<NationalityCollection> _nationalityCollection;
        public ObservableCollection<NationalityCollection> NationalityList
        {
            get
            {
                _nationalityCollection = new ObservableCollection<NationalityCollection>(personnel.GetNationality());
                return _nationalityCollection;
            }
        }
        void personnel_EmployeeChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                OnPropertyChanged("Employee");
            }));
        }

        BindingGroup _UpdateBindingGroup;
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    OnPropertyChanged("UpdateBindingGroup");
                }
            }
        }
        public int SelectedIndex { get; set; }
        object _SelectedEmployee;
        public object SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }
            set
            {
                if (_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                    OnPropertyChanged("SelectedEmployee");
                }
            }
        }

        //Search employee record by typing text in textbox
        private ICollectionView _dataGridCollection;
        private string _TextSearch;
        public string TextSearch
        {
            get { return _TextSearch; }
            set
            {
                _TextSearch = value;
                OnPropertyChanged("TextSearch");
                FilterCollection();
            }
        }

        public ICollectionView DataGridCollection
        {
            get 
            { 
                return _dataGridCollection; 
            }
            set 
            { 
                _dataGridCollection = value; 
                OnPropertyChanged("DataGridCollection"); 
            }
        }

        private void FilterCollection()
        {
            
            
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as User;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_TextSearch))
                {
                    return data.ID.Contains(_TextSearch) || data.LastName.Contains(_TextSearch) || data.FirstName.Contains(_TextSearch) || data.Gender.Contains(_TextSearch) || data.Nationality.Contains(_TextSearch) || data.Language.Contains(_TextSearch) || data.Address.Contains(_TextSearch);
                }
                return true;
            }
            return false;
        }

    }
}
