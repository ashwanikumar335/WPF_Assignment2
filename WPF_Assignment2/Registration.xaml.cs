using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegistrationViewModel registrationVM; 
        public Registration()
        {
            InitializeComponent();
            registrationVM = new RegistrationViewModel();
            this.DataContext = registrationVM;
        }
        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            registrationVM.Password = passwordBox1.Password;
            registrationVM.ConfirmPassword = passwordBoxConfirm.Password;
        }
    }
}
