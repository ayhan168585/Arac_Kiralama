using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ModelManager:IModelService
    {
        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IDataResult<List<Model>> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Model>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(),Messages.ModelsListed);
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(p => p.Id == id),Messages.ModelDetailListed);
        }

        public IResult Add(Model model)
        {
           _modelDal.Add(model);
           return new SuccessResult(Messages.ModelAdded);
        }

        public IResult Update(Model model)
        {
           _modelDal.Update(model);
           return new SuccessResult(Messages.ModelUpdated);
        }

        public IResult Delete(Model model)
        {
           _modelDal.Delete(model);
           return new SuccessResult(Messages.ModelDeleted);
        }
    }
}
