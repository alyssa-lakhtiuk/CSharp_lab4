//using DevExpress.Data.Browsing;
using System;
using System.Windows;
using System.Windows.Controls;


namespace CSharp_lab4
{
    public partial class DateInputUserControl : Window
    {
        private DateInfo dateFromUser;

        public DateInputUserControl()
        {
            InitializeComponent();
            dateFromUser = new DateInfo();
            DataContext = dateFromUser;
            if (dateFromUser.Close == null)
            {
                dateFromUser.Close = new Action(this.Close);
            }
        }

        public DateInputUserControl(Person user)
        {
            InitializeComponent();
            dateFromUser = new DateInfo(user);
            DataContext = dateFromUser;
            if (dateFromUser.Close == null)
            {
                dateFromUser.Close = new Action(this.Close);
            }
        }

        //public DateInputUserControl(Person user){
        //    InitializeComponent();
        //    dateFromUser = new DateInfo();
        //    DataContext = dateFromUser;
        //}

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DatePicker1.SelectedDate;
            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }


    }
}
