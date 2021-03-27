using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CardOperation:IEntity
    {
        public int Id { get; set; }
        public int CreditCardId { get; set; }
        public string OperationName { get; set; }
        public decimal OperationPrice { get; set; }
        public string Description { get; set; }
    }
}
