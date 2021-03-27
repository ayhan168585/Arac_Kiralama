﻿
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class CarDetailDto:IDto

    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string Plaka { get; set; }
        public string Description { get; set; }
    }
}