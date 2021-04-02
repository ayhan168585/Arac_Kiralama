using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null);
        IDataResult<List<RentalDetailDto>> GetRentalDetail(Expression<Func<RentalDetailDto, bool>> filter = null);
        IDataResult<RentalDetailDto> GetRentalById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalsByBrandId(int brandId);
        IDataResult<List<RentalDetailDto>> GetRentalsByModelId(int modelId);
        IDataResult<List<RentalDetailDto>> GetRentalsByUserId(int userId);
        IDataResult<List<RentalDetailDto>> GetRentalsByCustomerId(int customerId);
        IDataResult<Rental> GetById(int id);
        IResult Add(Rental rental);
        IResult AddWithFindexScore(RentalDetailDto rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
