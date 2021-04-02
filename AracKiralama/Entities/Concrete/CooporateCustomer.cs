using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class CooporateCustomer:User,IEntity
    {
      public string CompanyName { get; set; }
    }
}
