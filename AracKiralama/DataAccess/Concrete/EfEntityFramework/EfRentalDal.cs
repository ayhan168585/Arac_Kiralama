using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfEntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, AracKiralamaContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (AracKiralamaContext context = new AracKiralamaContext())
            {
                var result = from rental in context.Rentals
                             join user in context.Users
                                 on rental.UserId equals user.Id
                             join coop in context.CooporateCustomers
                                 on user.Id equals coop.Id
                             join car in context.Cars
                                  on rental.CarId equals car.Id
                             join brand in context.Brands
                                 on car.BrandId equals brand.Id
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
                                 Id = rental.Id,
                                 UserId = user.Id,
                                 CarId = car.Id,
                                 RequiredFindexScore = rental.RequiredFindexScore,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 BankId = bank.Id,
                                 CreditCardId = credit.Id,
                                 CardOperationId = operation.Id,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = coop.CompanyName,
                                 TcNo = user.TcNo,
                                 FindexScore = user.FindexScore,
                                 BankName = bank.BankName,
                                 CreditCardNumber = credit.CreditCardNumber,
                                 OperationName = operation.OperationName,
                                 RentPrice = rental.RentPrice,
                                 Description = rental.Description



                             };

                return result.ToList();
            }
        }

        public void AddWithFindexScore(RentalDetailDto rental)
        {
            using (AracKiralamaContext context=new AracKiralamaContext())
            {
                var addedEntity = context.Entry(rental);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
