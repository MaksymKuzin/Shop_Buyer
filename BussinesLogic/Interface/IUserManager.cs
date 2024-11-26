using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Interface
{
    public interface IUserManager
    {
        int AddUser(UserDto user);
        UserDto GetUserById(int userId);
        public object GetUserByEmail(string? email);
    }

}
