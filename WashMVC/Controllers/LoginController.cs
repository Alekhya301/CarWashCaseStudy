using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WashMVC.Models;
using WashMVC.Repositories;

namespace WashMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Email, Password")] LoginModel login)
            
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewmodel newUser = new UserViewmodel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.PostResponse("Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewmodel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(login.Email, false);
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "The Email or Password provided is incorrect";
                    }
                }
            }
            catch
            {

            }
            return View();

        }

        public ActionResult LogOff()
        {

            //Session.Remove("UserID");

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        //Action method to create user
        #region
        public async Task<ActionResult> Create(UserViewmodel user)
        {
            if (ModelState.IsValid)
            {
                UserViewmodel newUser = new UserViewmodel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("UserTable", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewmodel>(apiResponse);
                    }
                }



                return RedirectToAction("Index", "User");
            }
            return View(user);
        }
        #endregion

    }

}
