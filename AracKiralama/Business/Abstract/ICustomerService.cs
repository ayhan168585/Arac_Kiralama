using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<CooporateCustomer>> GetAll(Expression<Func<CooporateCustomer, bool>> filter = null);
        IDataResult<CooporateCustomer> GetById(int id);
        IResult Add(CooporateCustomer customer);
        IResult Update(CooporateCustomer customer);
        IResult Delete(CooporateCustomer customer);
    }
}
