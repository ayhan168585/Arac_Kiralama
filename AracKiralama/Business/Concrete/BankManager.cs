using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BankManager:IBankService
    {
        private IBankDal _bankDal;

        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public List<Bank> GetAll(Expression<Func<Bank, bool>> filter = null)
        {
            return _bankDal.GetAll();
        }

        public Bank GetById(int id)
        {
            return _bankDal.Get(p => p.Id == id);
        }

        public void Add(Bank bank)
        {
           _bankDal.Add(bank);
        }

        public void Update(Bank bank)
        {
            _bankDal.Update(bank);
        }

        public void Delete(Bank bank)
        {
           _bankDal.Delete(bank);
        }
    }
}
