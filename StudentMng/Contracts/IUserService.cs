using StudentMng.Areas.Users.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMng.Contracts
{
    public interface IUserService
    {
        void CreateUser(User user);
        //bool IsValidate(string username, string password);
        (string username, string role)? Authenticate(User user);
    }
}
