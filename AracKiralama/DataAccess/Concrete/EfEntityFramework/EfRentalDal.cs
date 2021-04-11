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
                             join car in context.Cars
                                  on rental.CarId equals car.Id
                             join customer in context.Customers
                                 on rental.CustomerId equals customer.Id
                             join brand in context.Brands
                                 on rental.BrandId equals brand.Id
                             join color in context.Colors
                                   on rental.ColorId equals color.Id
                             join credit in context.CreditCards
                                 on rental.CreditCardId equals credit.Id
                            

                             select new RentalDetailDto()
                             {
                                 Id = rental.Id,
                                 UserId = user.Id,
                                 CarId = car.Id,
                                 RequiredFindexScore = car.RequiredFindexScore,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 CreditCardId = credit.Id,
                                 Deposit = credit.Deposit,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 CreditCardNumber = credit.CreditCardNumber,
                                 RentPrice = rental.RentPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 TotalPrice = rental.TotalPrice,
                                 Description = rental.Description



                             };

                return result.ToList();
            }
        }

        public void AddWithFindexScore(RentalDetailDto rental)
        {
            using (AracKiralamaContext context = new AracKiralamaContext())
            {
                var addedEntity = context.Entry(rental);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
