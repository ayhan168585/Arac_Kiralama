using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ExternalServices.CreditCardDeposit
{
    public class CreditCardDeposit
    {
        public static decimal MakeDeposit()
        {
            Random random=new Random();
            var deposit = random.Next(1000, 10000);
            return deposit;
        }
    }
}
