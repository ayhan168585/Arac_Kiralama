using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankService
    {
        List<Bank> GetAll(Expression<Func<Bank, bool>> filter = null);
        Bank GetById(int id);
        void Add(Bank bank);
        void Update(Bank bank);
        void Delete(Bank bank);
    }
}
