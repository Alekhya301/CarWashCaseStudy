using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class AccountImplement : IAccountRepository
    {
        CarWashEntities _context = null;
        public AccountImplement(CarWashEntities context)
        {
            this._context = context;
        }
        public UserTable VerifyLogin(string Email, string Password)
        {
            
            UserTable user = null;
            try
            {
                var checkValidUser = _context.UserTables.Where(m => m.Email == Email &&
            m.Password == Password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    user = checkValidUser;
                }

                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        

    }
}