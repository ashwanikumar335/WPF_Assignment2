using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class ViewModelNotice : ViewModelBase
    {
        NoticeBusinessModel personnel;
        ObservableCollection<Model.Notice> _Notice;
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddNoticeCommand { get; set; }
        public RelayCommand DeleteNoticeCommand { get; set; }

        public ViewModelNotice()
        {
            personnel = new NoticeBusinessModel();
            CancelCommand = new RelayCommand(DoCancel);
            SaveCommand = new RelayCommand(DoSave);
            AddNoticeCommand = new RelayCommand(AddNotice);
            DeleteNoticeCommand = new RelayCommand(DeleteNotice);
            personnel.NoticeChanged += new EventHandler(personnel_NoticeChanged);
            UpdateBindingGroup = new BindingGroup { Name = "Group1" };
        }

        public ObservableCollection<Model.Notice> Notice
        {
            get
            {
                _Notice = new ObservableCollection<Model.Notice>(personnel.GetNotice());
                return _Notice;
            }
        }

        void DoCancel(object param)
        {
            UpdateBindingGroup.CancelEdit();
            if (SelectedIndex == -1)    //This only closes if new - just to show you how CancelEdit returns old values to bindings
                SelectedNotice = null;
        }

        void DoSave(object param)
        {
            UpdateBindingGroup.CommitEdit();
            var notice = SelectedNotice as Model.Notice;
            if (SelectedIndex == -1)
            {
                personnel.AddNotice(notice);
                OnPropertyChanged("Notice"); // Update the list from the data source
            }
            else
                personnel.UpdateNotice(notice);

            SelectedNotice = null;
        }

        void AddNotice(object parameter)
        {
            SelectedNotice = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var notice = new Model.Notice();
            SelectedNotice = notice;
        }

        void DeleteNotice(object parameter)
        {
            var notice = SelectedNotice as Model.Notice;
            if (SelectedIndex != -1)
            {
                personnel.DeleteNotice(notice);
                OnPropertyChanged("Notice"); // Update the list from the data source
            }
            else
                SelectedNotice = null; // Simply discard the new object
        }

        void personnel_NoticeChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                OnPropertyChanged("Notice");
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
        object _SelectedNotice;
        public object SelectedNotice
        {
            get
            {
                return _SelectedNotice;
            }
            set
            {
                if (_SelectedNotice != value)
                {
                    _SelectedNotice = value;
                    OnPropertyChanged("SelectedNotice");
                }
            }
        }
    }
}
