using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class WelcomeViewModel : ViewModelBase
    {
        //Manage User Window Open
        private ICommand _ManageUserButton;
        public ICommand ManageUserCommand
        {
            get
            {
                if (_ManageUserButton == null)
                {
                    _ManageUserButton = new RelayCommand(param => this.ManageUser(), null);
                }

                return _ManageUserButton;
            }
        }
        private void ManageUser()
        {
            Users frmUsers = new Users();
            frmUsers.Show();
        }

        //Manage Issue window Open
        private ICommand _ManageIssueButton;
        public ICommand ManageIssueCommand
        {
            get
            {
                if (_ManageIssueButton == null)
                {
                    _ManageIssueButton = new RelayCommand(param => this.ManageIssue(), null);
                }

                return _ManageIssueButton;
            }
        }
        private void ManageIssue()
        {
            ManageIssues frmManageIssues = new ManageIssues();
            frmManageIssues.Show();
        }

        //Manage Notice Window Open
        private ICommand _ManageNoticeButton;
        public ICommand ManageNoticeCommand
        {
            get
            {
                if (_ManageNoticeButton == null)
                {
                    _ManageNoticeButton = new RelayCommand(param => this.ManageNotice(), null);
                }

                return _ManageNoticeButton;
            }
        }
        private void ManageNotice()
        {
            ManageNotice frmManageNotice = new ManageNotice();
            frmManageNotice.Show();
        }

        //Search Employee Window Open
        private ICommand _SearchEmployeeButton;
        public ICommand SearchEmployeeCommand
        {
            get
            {
                if (_SearchEmployeeButton == null)
                {
                    _SearchEmployeeButton = new RelayCommand(param => this.SearchEmployee(), null);
                }

                return _SearchEmployeeButton;
            }
        }
        private void SearchEmployee()
        {
            SearchEmployee frmSearchEmployee = new SearchEmployee();
            frmSearchEmployee.Show();
        }
    }
}
