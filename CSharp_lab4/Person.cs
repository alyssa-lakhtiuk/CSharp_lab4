using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace CSharp_lab4
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _emailAdress;
        private readonly DateTime _dateBirth;
        readonly DateTime defaultDateBirth = new DateTime(2001, 01, 01);
        readonly string defaultEmail = "empty@email.com";

        readonly bool _isAdult;
        readonly string _sunSign;
        readonly string _chinesseSign;
        readonly bool _isBirthday;
        private int _age;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        public string EmailAdress
        {
            get
            {
                return _emailAdress;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return _dateBirth;
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

        //public Person()
        //{

        //}

        public Person(string firstName, string lastName, string emailAdress, DateTime dateBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAdress = emailAdress;
            check_email(emailAdress);
            try
            {
                dateValid(dateBirth);
            }
            catch (Exception ex)
            {
                if (ex is exceptionsFold.DateFarInPast || ex is exceptionsFold.DateInFuture)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
            _dateBirth = dateBirth;

            _age = countAgeOfUser(dateBirth);
            _isAdult = (_age >= 18);
            _sunSign = countWestAstroSign(dateBirth);
            _chinesseSign = countWestAstroSign(dateBirth);
            _isBirthday = isBirtDayToday(dateBirth);    
        }

        public Person(string firstName, string lastName, string emailAdress)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAdress = emailAdress;
            _dateBirth = defaultDateBirth;
        }

        public Person(string firstName, string lastName, DateTime dateBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAdress = defaultEmail;
            _dateBirth = dateBirth;
        }


        enum WestSigns
        {
            Aries = 1,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

        enum EastSigns
        {
            Rat = 1,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig
        }


        public bool dateValid(DateTime selectedDateFromUser)
        {
            DateTime todayDate = DateTime.Today;
            int difference = todayDate.Year - selectedDateFromUser.Year;
            if (difference > 135)
            {
                throw new exceptionsFold.DateFarInPast(difference);
            }
            else if (difference < 0)
            {
                throw new exceptionsFold.DateInFuture(difference);
            }
            return true;
        }

        public int countAgeOfUser(DateTime selectedDateFromUser)
        {
            Thread.Sleep(1500);
            DateTime? todayDate = DateTime.Today;
            int age = todayDate.Value.Year - selectedDateFromUser.Year;
            if ((todayDate.Value.Day < selectedDateFromUser.Day && todayDate.Value.Month == selectedDateFromUser.Month) || (todayDate.Value.Month < selectedDateFromUser.Month))
            {
                age--;
            }
            return age;
        }

        public string countWestAstroSign(DateTime selectedDateFromUser)
        {
            Thread.Sleep(2000);
            int month = selectedDateFromUser.Month;
            int day = selectedDateFromUser.Day;
            WestSigns astroSign;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                astroSign = WestSigns.Aries;
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                astroSign = WestSigns.Taurus;
            }
            else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
            {
                astroSign = WestSigns.Gemini;
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                astroSign = WestSigns.Cancer;
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                astroSign = WestSigns.Leo;
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                astroSign = WestSigns.Virgo;
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                astroSign = WestSigns.Libra;
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
            {
                astroSign = WestSigns.Scorpio;
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                astroSign = WestSigns.Sagittarius;
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                astroSign = WestSigns.Capricorn;
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                astroSign = WestSigns.Aquarius;
            }
            else
            {
                astroSign = WestSigns.Pisces;
            }
            return astroSign.ToString();
        }

        public string countEastAstroSign(DateTime selectedDateFromUser)
        {
            Thread.Sleep(2000);
            int numOfSign = (selectedDateFromUser.Year - 1900) % 12 + 1;
            EastSigns astroSign = (EastSigns)numOfSign;
            return astroSign.ToString();
        }

        public bool isBirtDayToday(DateTime selectedDateFromUser)
        {
            Thread.Sleep(1000);
            DateTime todayDate = DateTime.Today;
            if (selectedDateFromUser.Day == todayDate.Day && selectedDateFromUser.Month == todayDate.Month)
            {
                MessageBox.Show("Happy Birthady! Be Happy and free!");
                //IsBirthday = true;
                return true;
            }
            return false;
        }

        private void check_email(string emailAdress)
        {
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!regex.IsMatch(emailAdress))
                throw new exceptionsFold.WrongEmail(emailAdress);
        }

    }
}
