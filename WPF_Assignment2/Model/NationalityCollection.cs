using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPF_Assignment2.ViewModel;

namespace WPF_Assignment2.Model
{
    public class NationalityCollection : ViewModelBase
    {
        ICollectionView _nationalityCollection;
        public ICollectionView NationalityView
        {
            get { return _nationalityCollection; }
            set
            {
                if (value != _nationalityCollection)
                {
                    _nationalityCollection = value;
                    OnPropertyChanged("NationalityCollection");
                }
            }
        }

        private string _nationality;
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                OnPropertyChanged("Nationality");
            }
        }
    }
}
