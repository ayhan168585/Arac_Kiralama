using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null);
        List<RentalDetailDto> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null);
        RentalDetailDto GetRentalById(int rentalId);
        List<RentalDetailDto> GetCarsByCarId(int carId);
        List<RentalDetailDto> GetCarsByBrandId(int brandId);
        List<RentalDetailDto> GetCarsByModelId(int modelId);
        List<RentalDetailDto> GetCarsByUserId(int userId);
        List<RentalDetailDto> GetCarsByCustomerId(int customerId);
        Rental GetById(int id);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
    }
}
