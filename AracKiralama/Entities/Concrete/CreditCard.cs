using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CCV { get; set; }
        public DateTime ValidDate { get; set; }
        public decimal Deposit { get; set; }
        public string Description { get; set; }
    }
}
