﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EfEntityFramework
{
   
        public class EfUserDal : EfEntityRepositoryBase<User, AracKiralamaContext>, IUserDal
        {
            public List<OperationClaim> GetClaims(User user)
            {
                using (var context = new AracKiralamaContext())
                {
                    var result = from operationClaim in context.OperationClaims
                        join userOperationClaim in context.UserOperationClaims
                            on operationClaim.Id equals userOperationClaim.OperationClaimId
                        where userOperationClaim.UserId == user.Id
                        select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                    return result.ToList();

                }
            }
        }
    
}
