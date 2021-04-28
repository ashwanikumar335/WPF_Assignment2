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
    /// Interaction logic for ManageIssues.xaml
    /// </summary>
    public partial class ManageIssues : Window
    {
        public ManageIssues()
        {
            InitializeComponent();
            this.DataContext = new ViewModelIssue();
        }
    }
}
