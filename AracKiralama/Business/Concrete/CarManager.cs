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
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return _carDal.GetCarDetails();
        }

        public CarDetailDto GetCarById(int carId)
        {
            return _carDal.GetCarDetails(p => p.CarId == carId).SingleOrDefault();
        }

        public List<CarDetailDto> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetCarDetails(p => p.BrandId == brandId);
        }

        public List<CarDetailDto> GetCarsByColorId(int colorId)
        {
            return _carDal.GetCarDetails(p => p.ColorId == colorId);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
           _carDal.Add(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
    }
}
