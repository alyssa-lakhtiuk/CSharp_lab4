using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_lab4.exceptionsFold
{
    class WrongEmail : Exception
    {
       
        public WrongEmail()
        {
        }

        public WrongEmail(string email)
            : base(String.Format("Invalid Email Address: {0}", email))
        {
        }
    }
}
