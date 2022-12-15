using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IAccountRepository
    {
        UserTable VerifyLogin(string Email, string Password);

    }
}