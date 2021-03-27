using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICardOperationService
    {
        List<CardOperation> GetAll(Expression<Func<CardOperation, bool>> filter = null);
        CardOperation GetById(int id);
        void Add(CardOperation operation);
        void Update(CardOperation operation);
        void Delete(CardOperation operation);
    }
}
