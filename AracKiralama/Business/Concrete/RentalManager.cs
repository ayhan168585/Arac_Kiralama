using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
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

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return _rentalDal.GetAll();
        }

        public List<RentalDetailDto> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            return _rentalDal.GetRentalDetails();
        }

        public RentalDetailDto GetRentalById(int rentalId)
        {
            return _rentalDal.GetRentalDetails(p => p.Id == rentalId).SingleOrDefault();
        }

        public List<RentalDetailDto> GetCarsByCarId(int carId)
        {
            return _rentalDal.GetRentalDetails(p => p.CarId == carId);
        }

        public List<RentalDetailDto> GetCarsByBrandId(int brandId)
        {
            return _rentalDal.GetRentalDetails(p => p.BrandId == brandId);
        }

        public List<RentalDetailDto> GetCarsByModelId(int modelId)
        {
            return _rentalDal.GetRentalDetails(p => p.ModelId == modelId);
        }

        public List<RentalDetailDto> GetCarsByUserId(int userId)
        {
            return _rentalDal.GetRentalDetails(p => p.UserId == userId);
        }

        public List<RentalDetailDto> GetCarsByCustomerId(int customerId)
        {
            return _rentalDal.GetRentalDetails(p => p.CustomerId == customerId);
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(p => p.Id == id);
        }

        public void Add(Rental rental)
        {
           _rentalDal.Add(rental);
        }

        public void Update(Rental rental)
        {
            _rentalDal.Update(rental);
        }

        public void Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
        }
    }
}
