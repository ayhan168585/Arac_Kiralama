using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null);
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
