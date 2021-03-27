using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string BrandName { get; set; }

    }
}
