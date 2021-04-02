using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard, bool>> filter = null)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(),Messages.CreditCardsListed);
        }

        public IDataResult<List<CreditCardDetailDto>> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CreditCardDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CreditCardDetailDto>>(_creditCardDal.GetCreditCardDetail(),Messages.CreditCardsListed);
        }

        public IDataResult<List<CreditCardDetailDto>> GetCreditCardDetailByBankId(int bankId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CreditCardDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CreditCardDetailDto>>(_creditCardDal.GetCreditCardDetail(p => p.BankId == bankId),Messages.CreditCardsListedByBank);
        }

        public IDataResult<CreditCardDetailDto> GetCreditCardDetailById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<CreditCardDetailDto>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CreditCardDetailDto>(_creditCardDal.GetCreditCardDetail(p => p.CreditCardId == id).SingleOrDefault(),Messages.CreditCardDetailListed);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<CreditCard>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(p => p.Id == id),Messages.CreditCardDetailListed);
        }

        public IResult Add(CreditCard card)
        {
            BusinessRules.Run(CheckIfCreditCardNumberOfBankExist(card.BankId, card.CreditCardNumber),CheckIfCreditCardValid());

           _creditCardDal.Add(card);
           return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Update(CreditCard card)
        {
            BusinessRules.Run(CheckIfCreditCardNumberOfBankExist(card.BankId, card.CreditCardNumber), CheckIfCreditCardValid());

            _creditCardDal.Update(card);
           return new SuccessResult(Messages.CreditCardUpdated);
        }

        public IResult Delete(CreditCard card)
        {
           _creditCardDal.Delete(card);
           return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IResult CheckIfCreditCardNumberOfBankExist(int bankId, string creditCardNumber)
        {
            var result = _creditCardDal.GetAll(p => p.BankId == bankId)
                .Where(p => p.CreditCardNumber == creditCardNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.CreditCardNumberOfThisBankExistError);
            }
            return new SuccessResult();
        }

        public IResult CheckIfCreditCardValid()
        {
            var result = _creditCardDal.GetAll(p => p.ValidDate >= DateTime.Now).Any();
            if (result)
            {
                return new ErrorResult(Messages.InvalidCreditCard);
            }
            return new SuccessResult();
        }

       
    }
}
