using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_lab4.exceptionsFold
{
    class DateFarInPast : Exception
    {
        public DateFarInPast()
        {
        }

        public DateFarInPast(int age)
            : base(String.Format("All you've left are bones!: {0}", age))
        {
        }
    }
}
