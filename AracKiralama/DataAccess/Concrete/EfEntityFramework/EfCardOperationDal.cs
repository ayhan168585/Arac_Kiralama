﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EfEntityFramework
{
    public class EfCardOperationDal:EfEntityRepositoryBase<CardOperation,AracKiralamaContext>,ICardOperationDal
    {
    }
}
