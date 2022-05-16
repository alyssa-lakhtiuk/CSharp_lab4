using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_lab4.exceptionsFold
{
    class DateInFuture : Exception
    {
        public DateInFuture()
        {
        }

        public DateInFuture(int age)
            : base(String.Format("You aren't even born!: {0}", age))
        {
        }
    }
}
