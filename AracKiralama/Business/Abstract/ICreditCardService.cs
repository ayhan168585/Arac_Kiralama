using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard, bool>> filter = null);
        IDataResult<List<CreditCardDetailDto>> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null);
        IDataResult<List<CreditCardDetailDto>> GetCreditCardDetailByBankId(int bankId);
        IDataResult<CreditCardDetailDto> GetCreditCardDetailById(int cardid);
        IDataResult<CreditCard> GetById(int id);
        IResult Add(CreditCard card);
        IResult Update(CreditCard card);
        IResult Delete(CreditCard card);
    }
}
