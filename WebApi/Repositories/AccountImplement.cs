using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
                var userFound = _context.UserTables.Where(u => u.Email == Email && u.Password == Password).SingleOrDefault();

                if (userFound != null)
                {
                    user = userFound;
                }
                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;

        }



    }
}