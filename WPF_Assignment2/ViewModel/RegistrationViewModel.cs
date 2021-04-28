using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WPF_Assignment2.GenericMessages;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        public string Password
        {
            get
            {
                return RegistrationModel.passwordBox1;
            }
            set
            {
                RegistrationModel.passwordBox1 = value;
                OnPropertyChanged();
            }
        }
        public string ConfirmPassword
        {
            get
            {
                return RegistrationModel.passwordBoxConfirm;
            }
            set
            {
                RegistrationModel.passwordBoxConfirm = value;
                OnPropertyChanged();
            }
        }
        public RegistrationModel RegistrationModel { get; set; }
        public GenericEmployeeOperations GenericEmpOp { get; set; }

        public RegistrationViewModel()
        {
            RegistrationModel = new RegistrationModel();
            GenericEmpOp = new GenericEmployeeOperations();
        }

        //Login
        private ICommand _LoginButton;
        public ICommand LoginButton
        {
            get
            {
                if (_LoginButton == null)
                {
                    _LoginButton = new RelayCommand(param => this.Login(), null);
                }

                return _LoginButton;
            }
        }
        private void Login()
        {
            Login frmLogin = new Login();
            Registration frmRegistration = new Registration();
            frmRegistration.Close();
            frmLogin.Show();
        }

        //Registration
        private ICommand _submitClick;
        public ICommand SubmitClick
        {
            get
            {
                if (_submitClick == null)
                {
                    _submitClick = new RelayCommand(param => this.Register(), null);
                }

                return _submitClick;
            }
        }
        private void Register()
        {
            RegEx regObj = new RegEx();
            Common cmnObj = new Common();
            if (RegistrationModel.textBoxEmail.Length == 0)
            {
                RegistrationModel.errormessage = GenericError.strEmptyEmail;
            }
            else if (!Regex.IsMatch(RegistrationModel.textBoxEmail, regObj.strRegEmail))
            {
                RegistrationModel.errormessage = GenericError.strValidEmail;
            }
            else
            {
                if (RegistrationModel.passwordBox1.Length == 0)
                {
                    RegistrationModel.errormessage = GenericError.strPassword;
                }
                else if (RegistrationModel.passwordBoxConfirm.Length == 0)
                {
                    RegistrationModel.errormessage = GenericError.strConfirmPassword;
                }
                else if (RegistrationModel.passwordBox1 != RegistrationModel.passwordBoxConfirm)
                {
                    RegistrationModel.errormessage = GenericError.strMatchPassword;
                }
                else
                {
                    int status = GenericEmpOp.AddNewRecord(RegistrationModel.textBoxFirstName, RegistrationModel.textBoxLastName, RegistrationModel.textBoxEmail, RegistrationModel.passwordBox1, RegistrationModel.textBoxAddress, RegistrationModel.IsCheckBoxChecked);
                    if (status == 1)
                    {
                        RegistrationModel.errormessage = GenericError.strRegistrationSuccessful;
                        cmnObj.Reset("Registration");
                    }
                }
            }
        }


        //Reset
        private ICommand _resetClick;
        public ICommand ResetClick
        {
            get
            {
                if (_resetClick == null)
                {
                    _resetClick = new RelayCommand(param => this.Reset(), null);
                }

                return _resetClick;
            }
        }

        private void Reset()
        {
            Common cmnObj = new Common();
            cmnObj.Reset("Registration");
        }
        //Cancel
        private ICommand _cancelClick;
        public ICommand CancelClick
        {
            get
            {
                if (_cancelClick == null)
                {
                    _cancelClick = new RelayCommand(param => this.Cancel(), null);
                }

                return _cancelClick;
            }
        }
        private void Cancel()
        {
            Registration frmRegistration = new Registration();
            frmRegistration.Close();
        }


    }
}
