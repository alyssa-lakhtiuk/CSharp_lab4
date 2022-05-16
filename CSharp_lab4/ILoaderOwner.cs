using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace CSharp_lab4
{
    interface ILoaderOwner : INotifyPropertyChanged
    {
        public bool IsEnabled
        {
            get;
            set;
        }

        public Visibility LoaderVisibility
        {
            get;
            set;
        }
    }
}
