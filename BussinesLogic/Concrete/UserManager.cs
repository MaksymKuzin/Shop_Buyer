using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogic.Interface;
using DAL.Concrete;
using DAL.Interface;
using DTO;

namespace BussinesLogic.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public int AddUser(UserDto user)
        {
            return _userDal.AddUser(user);
        }

        public object GetUserByEmail(string? email)
        {
            return _userDal.GetUserByEmail(email);
        }

        public UserDto GetUserById(int userId)
        {
            return _userDal.GetUserById(userId);
        }
    }

}
