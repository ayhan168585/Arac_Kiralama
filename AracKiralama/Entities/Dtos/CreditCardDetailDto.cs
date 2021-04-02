using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Entities.Dtos
{
    public class CreditCardDetailDto
    {
        public int CreditCardId { get; set; }
        public int BankId { get; set; }
        public int UserId { get; set; }
        public int CardOperationId { get; set; }
        public string BankName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperationName { get; set; }
        public decimal OperationPrice { get; set; }
        public string CreditCardNumber { get; set; }
        public string CCV { get; set; }
        public DateTime ValidDate { get; set; }
        public decimal Deposit { get; set; }

    }
}
