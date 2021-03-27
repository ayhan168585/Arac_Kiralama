﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Utilities.Results;
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

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime); 
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == id),Messages.CustomerDetailListed);
        }

        public IResult Add(Customer customer)
        {
           _customerDal.Add(customer);
           return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
           _customerDal.Update(customer);
           return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
