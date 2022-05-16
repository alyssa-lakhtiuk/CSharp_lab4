using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharp_lab4
{
    public class DateInfo : INotifyPropertyChanged, ILoaderOwner
    {
        private Person _person = null;
        private DateTime selectedDateFromUser;
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        private string _firstName;
        private string _lastName;
        private string _emailAdress;

        readonly bool _isAdult;
        readonly string _sunSign;
        readonly string _chinesseSign;
        readonly bool _isBirthday;
        private int _age;

        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;

        internal DateInfo(Person person){
            _person = person;
            FirstName = person.FirstName;
            LastName = person.LastName;
            EmailAdress = person.EmailAdress;
            SelectedDateFromUser = person.DateBirth; 

        }

        internal DateInfo()
        {

        }

        public Action Close { get; set; }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get
            {
                return _loaderVisibility;
            }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(proceed, o=>CanExecute()));
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string EmailAdress
        {
            get
            {
                return _emailAdress;
            }
            set
            {
                _emailAdress = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chinesseSign;
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public bool IsBirtday
        {
            get
            {
                return _isBirthday;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public DateTime SelectedDateFromUser
        {
            get
            {
                return selectedDateFromUser;
            }
            set
            {
                selectedDateFromUser = value;
                OnPropertyChanged();
            }
        }


        

        private void proceed(object obj)
        {
            if(_person != null)
            {
                StationManager.DataStorage.EditUser(_person, new Person(FirstName, LastName, EmailAdress, SelectedDateFromUser));
            }

            else
            {
                StationManager.DataStorage.AddUser(new Person(FirstName, LastName, EmailAdress, SelectedDateFromUser));
            }
            
            //bool check = false;
            //try
            //{
            //    check = dateValid();
            //}
            //catch (Exception ex)
            //{
            //    if (ex is exceptionsFold.DateFarInPast || ex is exceptionsFold.DateInFuture)
            //    {
            //        MessageBox.Show($"Exception: {ex.Message}");
            //    }
            //}
            //try
            //{
            //    check_email();
            //}
            //catch (exceptionsFold.WrongEmail ex)
            //{
            //    MessageBox.Show($"Exception: {ex.Message}");
            //}
            //if (check)
            //{
            //    try
            //    {
            //        //LoaderManager.Instance.ShowLoader();
            //        string sunSign = countEastAstroSign();
            //        int age = countAgeOfUser();
            //        string chinesseSign = countWestAstroSign();
            //        bool isBirthDay = isBirtDayToday();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Something went wrong: {ex.Message}");
            //        return;
            //    }
            //    finally
            //    {
                    
            //        //LoaderManager.Instance.HideLoader();
            //    }
            //}
        }
        

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(_person.FirstName) && !String.IsNullOrWhiteSpace(_person.LastName);
        }

        

      

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(Cancel, o => IsCorrect()));
            }
        }

        public Action CloseAction { get; set; }

        private void Cancel(object obj)
        {
            CloseAction();
        }

        private bool IsCorrect()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_emailAdress);
        }


        //private void update(object? sender, PropertyChangedEventArgs e)
        //{
        //    if(e.PropertyName == nameof(SelectedDateFromUser))
        //    {
        //        //PropertyChanged?.Invoke(this, nameof(ChineseCalendar));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
