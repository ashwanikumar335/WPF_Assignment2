using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using WPF_Assignment2.Model;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;

namespace WPF_Assignment2.ViewModel
{
    class ViewModelIssue : ViewModelBase
    {
        IssueBusinessModel personnel;
        ObservableCollection<Model.Issue> _Issue;
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddIssueCommand { get; set; }
        public RelayCommand DeleteIssueCommand { get; set; }

        public ViewModelIssue()
        {
            personnel = new IssueBusinessModel();
            CancelCommand = new RelayCommand(DoCancel);
            SaveCommand = new RelayCommand(DoSave);
            AddIssueCommand = new RelayCommand(AddIssue);
            DeleteIssueCommand = new RelayCommand(DeleteIssue);
            personnel.IssueChanged += new EventHandler(personnel_IssueChanged);
            UpdateBindingGroup = new BindingGroup { Name = "Group1" };
        }

        public ObservableCollection<Model.Issue> Issue
        {
            get
            {
                _Issue = new ObservableCollection<Model.Issue>(personnel.GetIssues());
                return _Issue;
            }
        }

        void DoCancel(object param)
        {
            UpdateBindingGroup.CancelEdit();
            if (SelectedIndex == -1)    //This only closes if new - just to show you how CancelEdit returns old values to bindings
                SelectedIssue = null;
        }

        void DoSave(object param)
        {
            UpdateBindingGroup.CommitEdit();
            var issue = SelectedIssue as Model.Issue;
            if (SelectedIndex == -1)
            {
                personnel.AddIssue(issue);
                OnPropertyChanged("Issue"); // Update the list from the data source
            }
            else
                personnel.UpdateIssue(issue);

            SelectedIssue = null;
        }

        void AddIssue(object parameter)
        {
            SelectedIssue = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var issue = new Model.Issue();
            SelectedIssue = issue;
        }

        void DeleteIssue(object parameter)
        {
            var issue = SelectedIssue as Model.Issue;
            if (SelectedIndex != -1)
            {
                personnel.DeleteIssue(issue);
                OnPropertyChanged("Issue"); // Update the list from the data source
            }
            else
                SelectedIssue = null; // Simply discard the new object
        }
        ObservableCollection<PriorityCollection> _priorityCollection;
        public ObservableCollection<PriorityCollection> PriorityList
        {
            get
            {
                _priorityCollection = new ObservableCollection<PriorityCollection>(personnel.GetPriority());
                return _priorityCollection;
            }
        }
        void personnel_IssueChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                OnPropertyChanged("Issue");
            }));
        }

        BindingGroup _UpdateBindingGroup;
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    OnPropertyChanged("UpdateBindingGroup");
                }
            }
        }
        public int SelectedIndex { get; set; }
        object _SelectedIssue;
        public object SelectedIssue
        {
            get
            {
                return _SelectedIssue;
            }
            set
            {
                if (_SelectedIssue != value)
                {
                    _SelectedIssue = value;
                    OnPropertyChanged("SelectedIssue");
                }
            }
        }
    }
}
