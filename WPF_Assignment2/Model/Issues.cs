using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class Issue : ViewModelBase
    {
        private string _issueId;
        private string _title;
        private string _postedOn;
        private string _postedBy;
        private string _status;
        private string _priority;

        public Issue()
        {
        }

        public string IssueID
        {
            get { return _issueId; }
            set
            {
                _issueId = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string PostedOn
        {
            get { return _postedOn; }
            set
            {
                _postedOn = string.Format("{0:MM/dd/yyyy}", value);
                OnPropertyChanged();
            }
        }

        public string PostedBy
        {
            get { return _postedBy; }
            set
            {
                _postedBy = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged();
            }
        }
    }
}
