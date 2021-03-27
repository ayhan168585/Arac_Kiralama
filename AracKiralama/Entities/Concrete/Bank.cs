using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Bank:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
    }
}
