using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_lab4
{
    static class StationManager
    {
        internal static Person _currentUser { get; set; }
        private static IUserStorage _dataStorage;
        internal static IUserStorage DataStorage
        {
            get 
            { 
                return _dataStorage; 
            }
        }
        internal static void Initialize(IUserStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
    }
}
