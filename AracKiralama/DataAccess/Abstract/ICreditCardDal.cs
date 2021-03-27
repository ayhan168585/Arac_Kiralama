using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal:IEntityRepository<CreditCard>
    {
        List<CreditCardDetailDto> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null);
    }
}
