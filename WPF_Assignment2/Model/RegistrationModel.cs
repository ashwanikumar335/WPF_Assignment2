using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Windows.Controls;
using WPF_Assignment2.GenericMessages;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class RegistrationModel : ViewModelBase
    {
        private string _strtextBoxFirstName;
        private string _strtextBoxLastName;
        private string _strtextBoxEmail;
        private string _strtextBoxAddress;
        private string _strpasswordBox1;
        private string _strpasswordBoxConfirm;
        private string _errormessage;
        private bool _isCheckBoxCheckedProperty;
        public string textBoxFirstName
        {
            get
            {
                return _strtextBoxFirstName;
            }
            set
            {
                _strtextBoxFirstName = value;
                OnPropertyChanged();
            }
        }

        public string textBoxLastName
        {
            get
            {
                return _strtextBoxLastName;
            }
            set
            {
                _strtextBoxLastName = value;
                OnPropertyChanged();
            }
        }
        public string textBoxEmail
        {
            get
            {
                return _strtextBoxEmail;
            }
            set
            {
                _strtextBoxEmail = value;
                OnPropertyChanged();
            }
        }
        public string textBoxAddress
        {
            get
            {
                return _strtextBoxAddress;
            }
            set
            {
                _strtextBoxAddress = value;
                OnPropertyChanged();
            }
        }
        public string passwordBox1
        {
            get
            {
                return _strpasswordBox1;
            }
            set
            {
                _strpasswordBox1 = value;
                OnPropertyChanged();
            }
        }
        public string passwordBoxConfirm
        {
            get
            {
                return _strpasswordBoxConfirm;
            }
            set
            {
                _strpasswordBoxConfirm = value;
                OnPropertyChanged();
            }
        }
        public string errormessage
        {
            get
            {
                return _errormessage;
            }
            set
            {
                _errormessage = value;
                OnPropertyChanged("_errormessage");
            }
        }
        public bool IsCheckBoxChecked
        {
            get
            {
                return _isCheckBoxCheckedProperty;
            }
            set
            {
                _isCheckBoxCheckedProperty = value;
                OnPropertyChanged("IsCheckBoxChecked");
            }
        }


    }
}
