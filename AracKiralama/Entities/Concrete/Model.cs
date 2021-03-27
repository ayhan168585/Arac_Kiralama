using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
    }
}
