using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.ExternalServices.FindexService
{
    public class FindFindexScore
    {
        public static int MakeFindexScore()
        {
            Random random=new Random();

            var FindexScore = random.Next(0, 1900);
            return FindexScore;
        }
    }
}
