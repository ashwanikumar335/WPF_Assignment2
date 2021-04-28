using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2
{
    /// <summary>
    /// Interaction logic for ManageNotice.xaml
    /// </summary>
    public partial class ManageNotice : Window
    {
        public ManageNotice()
        {
            InitializeComponent();
            this.DataContext = new ViewModelNotice();
        }
    }
}
