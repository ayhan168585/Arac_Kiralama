using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.Id == id),Messages.ColorDetailListed);
        }

        public IResult Add(Color color)
        {
            BusinessRules.Run(CheckIfColorNameExist(color.ColorName));
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
            BusinessRules.Run(CheckIfColorNameExist(color.ColorName));

            _colorDal.Update(color);
           return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
           return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult CheckIfColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll(p => p.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorNameExistError);
            }
            return new SuccessResult();
        }
    }
}
