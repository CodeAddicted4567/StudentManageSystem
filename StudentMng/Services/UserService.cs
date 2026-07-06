using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using StudentMng.Areas.Users.Data;
using StudentMng.Contracts;

namespace StudentMng.Services
{
    public class UserService : IUserService
    {
        IUserRepo repo;
        public UserService(IUserRepo _repo)
        {
            repo = _repo;
        }

        public void CreateUser(User users)
        {
            repo.AddUser(users);
        }
        //Fake validation
        /*public bool IsValidate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return repo.ValidateUser(username, password) != null;//Core of Login mechanism
        }*/
        public (string username, string role)? Authenticate(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return null;
            }
            return repo.ValidateUser(user.UserName, user.Password);
        }
    }
}