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
        AccountImplement _accountImplement;
        public LoginController()
        {
            this._accountImplement = new AccountImplement(new CarWashEntities());
        }

        [HttpPost]
        
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            UserTable user = null;
            try
            {
                user = _accountImplement.VerifyLogin(objlogin.Email, objlogin.Password);

                if (user != null)
                {
                    //return NotFound();
                    return Ok(user);

                }

            }
            catch (Exception ex)
            {

            }

            //return Ok(customer);
            return NotFound();

        }
        

    }   } 


