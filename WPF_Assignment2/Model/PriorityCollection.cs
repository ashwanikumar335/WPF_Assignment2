using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class PriorityCollection : ViewModelBase
    {
        ICollectionView _priorityCollection;
        public ICollectionView PriorityView
        {
            get { return _priorityCollection; }
            set
            {
                if (value != _priorityCollection)
                {
                    _priorityCollection = value;
                    OnPropertyChanged("PriorityCollection");
                }
            }
        }

        private string __priority;
        public string Priority
        {
            get { return __priority; }
            set
            {
                __priority = value;
                OnPropertyChanged("Priority");
            }
        }
    }
}
