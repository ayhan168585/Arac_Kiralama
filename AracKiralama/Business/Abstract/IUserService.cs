using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
