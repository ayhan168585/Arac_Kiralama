﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);

        void AddWithFindexScore(RentalDetailDto rental);
    }
}
