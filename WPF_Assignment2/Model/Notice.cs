using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class Notice : ViewModelBase
    {
        private string _noticeId;
        private string _title;
        private string _startdate;
        private string _expirydate;
        private string _postedBy;


        public Notice()
        {
        }

        public string NoticeID
        {
            get { return _noticeId; }
            set
            {
                _noticeId = value;
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
        public string StartDate
        {
            get { return _startdate; }
            set
            {
                _startdate = string.Format("{0:MM/dd/yyyy}", value);
                OnPropertyChanged();
            }
        }

        public string ExpiryDate
        {
            get { return _expirydate; }
            set
            {
                _expirydate = string.Format("{0:MM/dd/yyyy}", value);
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

    }
}
