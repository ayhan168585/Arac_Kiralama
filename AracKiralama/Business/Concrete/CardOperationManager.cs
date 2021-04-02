using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CardOperationManager:ICardOperationService
    {
        private ICardOperationDal _cardOperationDal;
        private ICreditCardService _cardService;

        public CardOperationManager(ICardOperationDal cardOperationDal, ICreditCardService cardService)
        {
            _cardOperationDal = cardOperationDal;
            _cardService = cardService;
        }

        public IDataResult<List<CardOperation>> GetAll(Expression<Func<CardOperation, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
             return new ErrorDataResult<List<CardOperation>>(Messages.MaintenanceTime);   
            }
            return new SuccessDataResult<List<CardOperation>>(_cardOperationDal.GetAll(),Messages.CreditCardOperationsListed); 
        }

        public IDataResult<CardOperation> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<CardOperation>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<CardOperation>(_cardOperationDal.Get(p => p.Id == id),Messages.CreditCardOperationDetailListed);
        }

        public IResult Add(CardOperation operation)
        {
            BusinessRules.Run(CheckIfCreditCardDeposit());
            _cardOperationDal.Add(operation);
            return new SuccessResult(Messages.CreditCardOperationAdded);
        }

        public IResult Update(CardOperation operation)
        {
            BusinessRules.Run(CheckIfCreditCardDeposit());

            _cardOperationDal.Update(operation);
           return new SuccessResult(Messages.CreditCardOperationUpdated);
        }

        public IResult Delete(CardOperation operation)
        {
           _cardOperationDal.Delete(operation);
           return new SuccessResult(Messages.CreditCardOperationDeleted);
        }
        public IResult CheckIfCreditCardDeposit()
        {
            var result = _cardService.GetCreditCardDetail(p => p.OperationPrice > p.Deposit);
            if (result.Success)
            {
                return new ErrorResult(Messages.InsufficientBalance);
            }
            return new SuccessResult();
        }

    }
}
