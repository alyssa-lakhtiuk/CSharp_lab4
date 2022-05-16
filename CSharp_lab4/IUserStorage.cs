using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CSharp_lab4
{
    interface IUserStorage
    {

        ObservableCollection<Person> UsersList { get; set; }
        void AddUser(Person user);
        void DeleteUser(Person user);
        void EditUser(Person user, Person finUser);
        void Save();
    }
}
