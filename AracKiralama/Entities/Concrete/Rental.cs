using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int RequiredFindexScore { get; set; }
        public int CreditCardId { get; set; }
        public decimal RentPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Description { get; set; }
    }
}
