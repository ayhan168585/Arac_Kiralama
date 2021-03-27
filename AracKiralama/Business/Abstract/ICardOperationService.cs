using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICardOperationService
    {
        IDataResult<List<CardOperation>> GetAll(Expression<Func<CardOperation, bool>> filter = null);
        IDataResult<CardOperation> GetById(int id);
        IResult Add(CardOperation operation);
        IResult Update(CardOperation operation);
        IResult Delete(CardOperation operation);
    }
}
