using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class Common : ViewModelBase
    {
        RegistrationModel _regModel = new RegistrationModel();
        LoginModel _logModel = new LoginModel();

        public void Reset(string frmName)
        {
            switch (frmName)
            {
                case "Registration":
                    _regModel.textBoxFirstName = "";
                    _regModel.textBoxLastName = "";
                    _regModel.textBoxEmail = "";
                    _regModel.textBoxAddress = "";
                    _regModel.passwordBox1 = "";
                    _regModel.passwordBoxConfirm = "";
                    break;
                case "Login":
                    _logModel.textBoxEmail = "";
                    _logModel.passwordBox1 = "";
                    break;
            }


        }

    }
}
