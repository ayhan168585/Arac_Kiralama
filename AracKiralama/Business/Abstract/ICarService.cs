using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto GetCarById(int carId);
        List<CarDetailDto> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarsByColorId(int colorId);
        Car GetById(Expression<Func<Car, bool>> filter);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
