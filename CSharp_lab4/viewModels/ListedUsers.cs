using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp_lab4.viewModels
{
    internal class ListedUsers : INotifyPropertyChanged
    {
        private Person _currentUser;
        private ObservableCollection<Person> _users;


        private RelayCommand<object> add;
        private RelayCommand<object> edit;
        private RelayCommand<object> save;
        private RelayCommand<object> delete;
        private RelayCommand<object> sortByFirstName;
        private RelayCommand<object> sortByLastName;
        private RelayCommand<object> sortByEmailAdress;
        private RelayCommand<object> sortByAge;
        private RelayCommand<object> sortBySunSign;
        private RelayCommand<object> sortByChinesseSign;


        public ObservableCollection<Person> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public Person CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
            }
        }

        public RelayCommand<object> Add
        {
            get
            {
                return add ?? (add = new RelayCommand<object>(AddUser));
            }
        }

        public RelayCommand<object> Edit
        {
            get
            {
                return edit ?? (edit = new RelayCommand<object>(EditUser));
            }
        }

        public RelayCommand<object> Save
        {
            get
            {
                return save ?? (save = new RelayCommand<object>(SaveUser));
            }
        }

        public RelayCommand<object> Delete
        {
            get
            {
                return delete ?? (delete = new RelayCommand<object>(DeleteUser));
            }
        }

        public RelayCommand<object> SortByFirstName
        {
            get
            {
                return sortByFirstName ?? (sortByFirstName = new RelayCommand<object>(o => SortUsersBy(o, 1)));
            }
        }

        public RelayCommand<object> SortByLastName
        {
            get
            {
                return sortByLastName ?? (sortByLastName = new RelayCommand<object>(o => SortUsersBy(o, 2)));
            }
        }


        public RelayCommand<object> SortByEmailAdress
        {
            get
            {
                return sortByEmailAdress ?? (sortByEmailAdress = new RelayCommand<object>(o => SortUsersBy(o, 3)));
            }
        }


        public RelayCommand<object> SortByAge
        {
            get
            {
                return sortByAge ?? (sortByAge = new RelayCommand<object>(o => SortUsersBy(o, 4)));
            }
        }


        public RelayCommand<object> SortBySunSign
        {
            get
            {
                return sortBySunSign ?? (sortBySunSign = new RelayCommand<object>(o => SortUsersBy(o, 5)));
            }
        }


        public RelayCommand<object> SortByChinesseSign
        {
            get
            {
                return sortByChinesseSign ?? (sortByChinesseSign = new RelayCommand<object>(o => SortUsersBy(o, 6)));
            }
        }

        private void AddUser(object obj)
        {
            DateInputUserControl mode = new DateInputUserControl();
            mode.ShowDialog();

            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        private void EditUser(object obj)
        {
            DateInputUserControl mode = new DateInputUserControl(_currentUser);
            mode.ShowDialog();

            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        private void SaveUser(object obj)
        {
            StationManager.DataStorage.Save(); 
        }

        private void DeleteUser(object obj)
        {
            
            StationManager.DataStorage.DeleteUser(_currentUser);
            _currentUser = null;
            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            
        }

        private void SortUsersBy(object obj, int num)
        {
            IOrderedEnumerable<Person> usersSort;
            switch (num)
            {
                case 1:
                    usersSort = from user in _users
                                   orderby user.FirstName
                                   select user;
                    break;
                case 2:
                    usersSort = from user in _users
                                orderby user.LastName
                                   select user;
                    break;
                case 3:
                    usersSort = from user in _users
                                orderby user.EmailAdress
                                   select user;
                    break;
                case 4:
                    usersSort = from user in _users
                                orderby user.Age
                                   select user;
                    break;
                case 5:
                    usersSort = from user in _users
                                orderby user.SunSign
                                   select user;
                    break;
                default:
                    usersSort = from user in _users
                                orderby user.ChineseSign
                                   select user;
                    break;
            }
            Users = new ObservableCollection<Person>(usersSort);
            StationManager.DataStorage.UsersList = Users;
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal ListedUsers()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        //private bool IsAbleToSubmit()
        //{
        //    return _currentUser != null;
        //}
    }
}
