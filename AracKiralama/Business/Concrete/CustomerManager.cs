using System;
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

        public IDataResult<List<CooporateCustomer>> GetAll(Expression<Func<CooporateCustomer, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<CooporateCustomer>>(Messages.MaintenanceTime); 
            }
            return new SuccessDataResult<List<CooporateCustomer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<CooporateCustomer> GetById(int id)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<CooporateCustomer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CooporateCustomer>(_customerDal.Get(p => p.Id == id),Messages.CustomerDetailListed);
        }

        public IResult Add(CooporateCustomer customer)
        {
           _customerDal.Add(customer);
           return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(CooporateCustomer customer)
        {
           _customerDal.Update(customer);
           return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(CooporateCustomer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
