using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class LoginModel : ViewModelBase
    {
        private string _strtextBoxEmail = string.Empty;
        private string _strpasswordBox1 = string.Empty;
        private string _errormessage;
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
    }
}
