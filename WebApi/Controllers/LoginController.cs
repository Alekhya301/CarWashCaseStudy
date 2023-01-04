using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Login")]
    
    public class LoginController : ApiController
    {
        IAccountRepository _accountImplement;
        public LoginController()
        {
            this._accountImplement = new AccountImplement(new CarWashEntities());
        }

        [HttpPost]
        [Route("")]
        
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            UserTable user = null;
            try
            {
                user = _accountImplement.VerifyLogin(objlogin.Email, objlogin.Password);

                if (user == null)
                {
                    return NotFound();
                   

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(user);
            

        }
        

    }   } 


