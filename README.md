﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core;
using Core.Business;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListed);
        }

        public IDataResult <List<CarDetailDto>> GetCarById(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult <List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult <List<CarDetailDto>>(_carDal.GetCarDetails().Where(p=>p.CarId==carId).ToList(),Messages.CarDetailListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId),Messages.CarsListedByBrand);
        }
        public IDataResult<List<CarDetailDto>> GetCarsByBrand(int brandId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(p=>p.BrandId==brandId).ToList(), Messages.CarsListedByBrand);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            Thread.Sleep(1000);
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>> (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(p=>p.ColorId==colorId).ToList(),Messages.CarsListedByColor);
        }

        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==id),Messages.CarDetailListed);
        }

        [SecuredOperation("car.add,admin")]
        public IResult Add(Car car)
        {
            BusinessRules.Run(CheckIfPlakaExist(car.Plaka));
           _carDal.Add(car);
           return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            BusinessRules.Run(CheckIfPlakaExist(car.Plaka));
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult CheckIfPlakaExist(string plaka)
        {
            var result = _carDal.GetAll(p => p.Plaka == plaka).Any();
            if (result)
            {
                return new ErrorResult(Messages.PlakaExistError);
            }
            return new SuccessResult();
        }
    }
}
