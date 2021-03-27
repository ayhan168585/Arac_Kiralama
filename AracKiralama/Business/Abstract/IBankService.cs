using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankService
    {
        IDataResult<List<Bank>> GetAll(Expression<Func<Bank, bool>> filter = null);
        IDataResult<Bank> GetById(int id);
        IResult Add(Bank bank);
        IResult Update(Bank bank);
        IResult Delete(Bank bank);
    }
}
