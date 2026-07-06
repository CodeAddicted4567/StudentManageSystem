using StudentMng.Areas.Users.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMng.Contracts
{
    public interface IUserRepo
    {
        void AddUser(User user);
        (string Username, string Role)? ValidateUser(string username, string password);
    }
}
