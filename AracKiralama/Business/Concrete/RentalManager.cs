﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Business;
using Core.ExternalServices.FindexService;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.RentalsListed);
        }

        public IDataResult<RentalDetailDto> GetRentalById(int rentalId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<RentalDetailDto>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails(p => p.Id == rentalId).SingleOrDefault(),Messages.RentalDetailListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p => p.CarId == carId),Messages.RentalsListedByCarId);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>> (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p => p.BrandId == brandId),Messages.RentalsListedByBrand);
        }

      

        public IDataResult<List<RentalDetailDto>> GetRentalsByUserId(int userId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p => p.UserId == userId),Messages.RentalsListedByUser);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCustomerId(int customerId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(p => p.CustomerId == customerId),Messages.RentalsListedByCustomer);
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id),Messages.RentalDetailListed);
        }

        public IResult Add(Rental rental)
        {
            var price = Convert.ToDecimal(rental.RentPrice);
            TimeSpan days = (rental.ReturnDate - rental.RentDate);
            rental.TotalPrice = price * Convert.ToInt32(days.TotalDays);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult AddWithFindexScore(RentalDetailDto rental)
        {
            BusinessRules.Run(CheckIfFindexScore(rental.FindexScore),CheckIfCreditCardDeposit(rental.Deposit));
                        var price = Convert.ToDecimal(rental.RentPrice);
            TimeSpan days = (rental.ReturnDate - rental.RentDate);
            rental.TotalPrice = price * Convert.ToInt32(days.TotalDays);
            _rentalDal.AddWithFindexScore(rental);
           return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult CheckIfFindexScore(int findexScore)
        {
            var FindexScore = FindFindexScore.MakeFindexScore();
            var result = _rentalDal.GetRentalDetails(p => p.RequiredFindexScore >= findexScore).Any();
            if (result)
            {
                return new ErrorResult(Messages.InsufficientFindexScore);
            }
            return new SuccessResult();
        }

        public IResult CheckIfCreditCardDeposit(decimal deposit)
        {
            var result = _rentalDal.GetRentalDetails(p => p.TotalPrice < deposit).Any();
            if (result)
            {
                return new ErrorResult(Messages.InsufficientBalance);
            }

            return new SuccessResult();
        }
    }
}
