using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EfEntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,AracKiralamaContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (AracKiralamaContext context=new AracKiralamaContext())
            {
                var result = from rental in context.Rentals
                    join user in context.Users
                        on rental.UserId equals user.Id
                    join customer in context.Customers
                        on user.Id equals customer.UserId
                    join car in context.Cars
                        on rental.CarId equals car.Id
                    join brand in context.Brands
                        on car.BrandId equals brand.Id
                    join model in context.Models
                        on brand.ModelId equals model.Id
                    join color in context.Colors
                        on car.ColorId equals color.Id
                    join credit in context.CreditCards
                        on rental.CreditCardId equals credit.Id
                    join bank in context.Banks
                        on credit.BankId equals bank.Id
                    join operation in context.CardOperations
                        on credit.Id equals operation.CreditCardId

                    select new RentalDetailDto()
                    {
                        Id=rental.Id,
                        UserId=user.Id,
                        CustomerId=customer.Id,
                        CarId = car.Id,
                        BrandId = brand.Id,
                        ModelId=model.Id,
                        ColorId = color.Id,
                        BankId=bank.Id,
                        CreditCardId = credit.Id,
                        CardOperationId = operation.Id,
                        CarName=car.CarName,
                        BrandName=brand.BrandName,
                        ModelName=model.ModelName,
                        ColorName=color.ColorName,
                        FirstName=user.FirstName,
                        LastName = user.LastName,
                        CompanyName=customer.CompanyName,
                        BankName=bank.BankName,
                        CreditCardNumber=credit.CreditCardNumber,
                        OperationName=operation.OperationName,
                        RentPrice=rental.RentPrice,
                        Description = rental.Description



                    };

                return result.ToList();
            }
        }
    }
}
