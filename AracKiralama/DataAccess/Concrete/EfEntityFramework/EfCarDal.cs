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
    public class EfCarDal:EfEntityRepositoryBase<Car,AracKiralamaContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (AracKiralamaContext context=new AracKiralamaContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.Id
                    join model in context.Models
                        on brand.ModelId equals model.Id
                    join color in context.Colors
                        on car.ColorId equals color.Id
                    select new CarDetailDto()
                    {
                        CarId = car.Id,
                        BrandId = brand.Id,
                        ModelId = model.Id,
                        ColorId = color.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ModelName = model.ModelName,
                        ColorName = color.ColorName,
                        Plaka = car.Plaka,
                        Description = car.Description


                    };
                return result.ToList();

            }
        }
    }
}
