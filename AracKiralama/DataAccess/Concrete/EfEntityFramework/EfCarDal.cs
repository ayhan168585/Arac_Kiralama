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
                    join image in context.CarImages
                        on car.Id equals image.CarId
                    join brand in context.Brands
                        on car.BrandId equals brand.Id
                   join color in context.Colors
                        on car.ColorId equals color.Id
                       
                    select new CarDetailDto()
                    {
                        CarId = car.Id,
                        BrandId = brand.Id,
                        ColorId = color.Id,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice,
                        ColorName = color.ColorName,
                        Plaka = car.Plaka,
                        RequiredFindexScore = car.RequiredFindexScore,
                        ImagePath = image.ImagePath,
                        Description = car.Description


                    };
                return result.ToList();

            }
        }
    }
}
