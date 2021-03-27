using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;


namespace Entities.Dtos
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int BankId { get; set; }
        public int CreditCardId { get; set; }
        public int CardOperationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public string BankName { get; set; }
        public string CreditCardNumber { get; set; }
        public string OperationName { get; set; }
        public decimal RentPrice { get; set; }
        public string Description { get; set; }
        
    }
}
