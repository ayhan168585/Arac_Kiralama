using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
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

        public List<Model> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            return _modelDal.GetAll();
        }

        public Model GetById(int id)
        {
            return _modelDal.Get(p => p.Id == id);
        }

        public void Add(Model model)
        {
           _modelDal.Add(model);
        }

        public void Update(Model model)
        {
           _modelDal.Update(model);
        }

        public void Delete(Model model)
        {
           _modelDal.Delete(model);
        }
    }
}
