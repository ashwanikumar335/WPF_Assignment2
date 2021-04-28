using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class DataGridSearchViewModel : ViewModelBase
    {
        public User UserModel { get; set; }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
                ItemsView.Refresh();
            }
        }

        private ICollectionView _itemsView;
        public ICollectionView ItemsView
        {
            get { return _itemsView; }
        }

        private ObservableCollection<User> info;
        public ObservableCollection<User> Items
        {
            get { return info ?? (info = new ObservableCollection<User>()); }
        }

        public DataGridSearchViewModel()
        {
            _itemsView = CollectionViewSource.GetDefaultView(Items);
            _itemsView.Filter = x => Filter(x as User);


        }

        private bool Filter(User model)
        {
            var searchstring = (SearchString ?? string.Empty).ToLower();

            return model != null &&
                 ((model.LastName ?? string.Empty).ToLower().Contains(searchstring) ||
                  (model.FirstName ?? string.Empty).ToLower().Contains(searchstring) ||
                  (model.ID ?? string.Empty).ToLower().Contains(searchstring) ||
                  (model.Address ?? string.Empty).ToLower().Contains(searchstring));
        }

        public ObservableCollection<User> UserInfo
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged("UserInfo");
            }
        }

    }
}

