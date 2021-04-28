using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Assignment2.GenericMessages;
using WPF_Assignment2.Model;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel loginVM;
        public Login()
        {
            InitializeComponent();
            loginVM = new LoginViewModel();
            this.DataContext = loginVM;

        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            loginVM.LoginModel.textBoxEmail = textBoxEmail.Text;
            loginVM.LoginModel.passwordBox1 = passwordBox1.Password;
        }
    }
}
