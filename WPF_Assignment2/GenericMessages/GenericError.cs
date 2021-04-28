using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Assignment2.GenericMessages
{
    public class GenericError
    {
        //Login Form error messages
        public const string strInvalidCredential = "Sorry! Please enter existing emailid/password.";
        public const string strEmptyEmail = "Enter an email.";
        public const string strValidEmail = "Enter a valid email.";
        public const string strInvalidUserPassword = "Username or Password Is Incorrect";

        //Registration Form error messages
        public const string strRegistrationSuccessful = "You have Registered successfully.";
        public const string strPassword = "Enter password.";
        public const string strConfirmPassword = "Enter Confirm password.";
        public const string strMatchPassword = "Confirm password must be same as password.";
    }
    public class RegEx
    {
        //Regular expression for Email
        public string strRegEmail = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

    }
}
