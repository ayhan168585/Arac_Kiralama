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
    public class BankManager:IBankService
    {
        private IBankDal _bankDal;

        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public IDataResult<List<Bank>> GetAll(Expression<Func<Bank, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Bank>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Bank>>(_bankDal.GetAll(),Messages.BanksListed);
        }

        public IDataResult<Bank> GetById(int id)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<Bank>(Messages.MaintenanceTime); 
            }

            return new SuccessDataResult<Bank>(_bankDal.Get(p => p.Id == id), Messages.BankDetailListed);
        }

        public IResult Add(Bank bank)
        {
           _bankDal.Add(bank);
           return new SuccessResult(Messages.BankAdded);

        }

        public IResult Update(Bank bank)
        {
            _bankDal.Update(bank);
            return new SuccessResult(Messages.BankUpdated);
        }

        public IResult Delete(Bank bank)
        {
           _bankDal.Delete(bank);
           return new SuccessResult(Messages.BankDeleted);
        }
    }
}
