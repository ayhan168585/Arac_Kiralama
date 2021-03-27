using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
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

        public List<CreditCard> GetAll(Expression<Func<CreditCard, bool>> filter = null)
        {
            return _creditCardDal.GetAll();
        }

        public List<CreditCardDetailDto> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null)
        {
            return _creditCardDal.GetCreditCardDetail();
        }

        public List<CreditCardDetailDto> GetCreditCardDetailByBankId(int bankId)
        {
            return _creditCardDal.GetCreditCardDetail(p => p.BankId == bankId);
        }

        public CreditCardDetailDto GetCreditCardDetailById(int cardid)
        {
            return _creditCardDal.GetCreditCardDetail(p => p.CreditCardId == cardid).SingleOrDefault();
        }

        public CreditCard GetById(int id)
        {
            return _creditCardDal.Get(p => p.Id == id);
        }

        public void Add(CreditCard card)
        {
           _creditCardDal.Add(card);
        }

        public void Update(CreditCard card)
        {
           _creditCardDal.Update(card);
        }

        public void Delete(CreditCard card)
        {
           _creditCardDal.Delete(card);
        }
    }
}
