using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharp_lab4
{
    class UsersStorage : IUserStorage
    {
        private ObservableCollection <Person> _users;

        public void Save()
        {
            FileRepository fr = new FileRepository();
            for (int i = 0; i < _users.Count; i++)
            {
                fr.AddUserOrUpdate(_users[i]);
            }
        }

        internal UsersStorage()
        {
            try
            {
                _users = JsonSerializer.Deserialize <ObservableCollection< Person >> (FileRepository.BaseFolder);
            } catch (Exception)
            {
                _users = new ObservableCollection<Person>();
                FillIn();
                Save();
            }
        }

        public ObservableCollection<Person> UsersList {
            get 
            {
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        public void AddUser(Person user)
        {
            if (canAdd(user))
            {
                _users.Add(user);
                Save();
            }

        }

        public void DeleteUser(Person user)
        {
            _users.Remove(user);
            Save();
        }

        public void EditUser(Person user, Person finalUser)
        {
            if (canAdd(finalUser))
            {
                _users[_users.IndexOf(user)] = finalUser;
            }
            else throw new ArgumentException("Something went wrong, can't do it(");
        }

        private void FillIn()
        {
            Random r = new Random();
            string[] firstNames = new string[] 
            {
                "Angelina", "Yulia", "Oleksandr", "Kyrylo",
                "Oksana", "Datyna", "Taras", "Dmytro", "Name1", "Name2", "Philip",
                "Rue", "Jules", "Volodymyr", "David", "Serhiy", "Yevhen"
            };
            string[] lastNames = new string[]
            {
                "Savchuk", "Kasianchuk", "Kotsiybynskiy", "Salata", "Romaniuk", "Lenartovych",
                "Piven", "Korol", "Kruta", "Lomonosov", "Bilokin", "Sydoruk", "Shevchenko", 
                "Coniyshenko", "Sagaiydachniy", "Opinch"
            };
            string[] partEmails = new string[]
            {
                "green", "yellow", "blue", "purple", "black", "sun", "sky", "grass", "red", "rose", 
                "tulip", "car", "computer", "machine", "learn", "exam", "teacher", "mark", "sql"
            };
            for (int i = 0; i <= 50; i++)
            {
                int firstNameNum = r.Next(1, firstNames.Length);
                int lastNameNum = r.Next(1, lastNames.Length);
                int partEmailNum = r.Next(1, partEmails.Length);
                AddUser(new Person($"{firstNames[firstNameNum]}", 
                    $"{lastNames[lastNameNum]}", 
                    $"{partEmails[partEmailNum]}@gmail.com", 
                    new DateTime(r.Next(1900, 2021), r.Next(1, 12), r.Next(1, 27))));
            }

        }
    

        private bool canAdd(Person user)
        {
            return !string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName) && !string.IsNullOrWhiteSpace(user.EmailAdress);
        }
    }
}
