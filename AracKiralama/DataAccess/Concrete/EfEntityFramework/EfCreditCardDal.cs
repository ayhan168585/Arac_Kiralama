using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EfEntityFramework
{
    public class EfCreditCardDal:EfEntityRepositoryBase<CreditCard,AracKiralamaContext>,ICreditCardDal
    {
        public List<CreditCardDetailDto> GetCreditCardDetail(Expression<Func<CreditCardDetailDto, bool>> filter = null)
        {
            using (AracKiralamaContext context=new AracKiralamaContext())
            {
                var result = from credit in context.CreditCards
                    join bank in context.Banks
                        on credit.BankId equals bank.Id
                    join user in context.Users
                        on bank.UserId equals user.Id
                    join operation in context.CardOperations
                        on credit.Id equals operation.CreditCardId
                    select new CreditCardDetailDto()
                    {
                        CreditCardId = credit.Id,
                        BankId = bank.Id,
                        UserId = user.Id,
                        CardOperationId = operation.Id,
                        BankName = bank.BankName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CreditCardNumber = credit.CreditCardNumber,
                        CCV = credit.CCV,
                        ValidDate = credit.ValidDate,
                        Deposit = credit.Deposit,
                        OperationName = operation.OperationName,
                        OperationPrice = operation.OperationPrice

                    };
                return result.ToList();
            }
        }
    }
}
