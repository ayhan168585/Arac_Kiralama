using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll(Expression<Func<Model, bool>> filter = null);
        Model GetById(int id);
        void Add(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
