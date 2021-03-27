using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerDal.Get(p => p.Id == id);
        }

        public void Add(Customer customer)
        {
           _customerDal.Add(customer);
        }

        public void Update(Customer customer)
        {
           _customerDal.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }
    }
}
