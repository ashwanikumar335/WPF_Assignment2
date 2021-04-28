using CsWpfMvvmPasswordBox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Assignment2.GenericMessages;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginModel LoginModel { get; set; }
        public LoginViewModel()
        {
            LoginModel = new LoginModel();
            GenericEmpOp = new GenericEmployeeOperations();
        }

        public GenericEmployeeOperations GenericEmpOp { get; set; }

        private ICommand _registerClick;
        public ICommand RegisterClickLink
        {
            get
            {
                if (_registerClick == null)
                {
                    _registerClick = new RelayCommand(param => this.Register(), null);
                }

                return _registerClick;
            }
        }
        private void Register()
        {
            Login frmLogin = new Login();
            Registration frmRegistration = new Registration();
            frmRegistration.Show();
            frmLogin.Close();
        }

        private ICommand _submitLoginButton;
        public ICommand SubmitLoginButton
        {
            get
            {
                if (_submitLoginButton == null)
                {
                    _submitLoginButton = new RelayCommand(param => this.SubmitButton(), null);
                }

                return _submitLoginButton;
            }
        }

        private void SubmitButton()
        {
            Common cmnObj = new Common();
            RegEx regObj = new RegEx();
            if (LoginModel.textBoxEmail.Length == 0)
            {
                LoginModel.errormessage = GenericError.strEmptyEmail;
            }
            else if (!Regex.IsMatch(LoginModel.textBoxEmail, regObj.strRegEmail))
            {
                LoginModel.errormessage = GenericError.strValidEmail;
            }
            else
            {
                var datatable = GenericEmpOp.Login(LoginModel.textBoxEmail, LoginModel.passwordBox1);
                if (datatable != null)
                {
                    string username = datatable.Rows[0][1].ToString();
                    string userType = datatable.Rows[0][6].ToString();
                    if (userType == "A")
                    {

                    }
                    Welcome welcomeCls = new Welcome();
                    welcomeCls.Show();
                }
                else
                {
                    LoginModel.errormessage = GenericError.strInvalidUserPassword;
                }
            }
        }


    }
}