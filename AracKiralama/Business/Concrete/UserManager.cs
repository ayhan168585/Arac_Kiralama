using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.Get(p => p.Id == id);
        }

        public void Add(User user)
        {
           _userDal.Add(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void Delete(User user)
        {
           _userDal.Delete(user);
        }
    }
}
