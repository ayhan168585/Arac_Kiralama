using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        List<CreditCard> GetAll(Expression<Func<CreditCard, bool>> filter = null);
        List<CreditCardDetailDto> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null);
        List<CreditCardDetailDto> GetCreditCardDetailByBankId(int bankId);
        CreditCardDetailDto GetCreditCardDetailById(int cardid);
        CreditCard GetById(int id);
        void Add(CreditCard card);
        void Update(CreditCard card);
        void Delete(CreditCard card);
    }
}
