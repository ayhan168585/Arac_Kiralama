using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CardOperationManager:ICardOperationService
    {
        private ICardOperationDal _cardOperationDal;

        public CardOperationManager(ICardOperationDal cardOperationDal)
        {
            _cardOperationDal = cardOperationDal;
        }

        public List<CardOperation> GetAll(Expression<Func<CardOperation, bool>> filter = null)
        {
            return _cardOperationDal.GetAll();
        }

        public CardOperation GetById(int id)
        {
            return _cardOperationDal.Get(p => p.Id == id);
        }

        public void Add(CardOperation operation)
        {
            _cardOperationDal.Add(operation);
        }

        public void Update(CardOperation operation)
        {
           _cardOperationDal.Update(operation);
        }

        public void Delete(CardOperation operation)
        {
           _cardOperationDal.Delete(operation);
        }
    }
}
