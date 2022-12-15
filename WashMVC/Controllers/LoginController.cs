using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WashMVC.Models;
using WashMVC.Repositories;

namespace WashMVC.Controllers
{
    public class LoginController : Controller
    {
        //public ActionResult LoginUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<ActionResult> LoginUser(LoginUser login)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            LoginUser newUser = new LoginUser();
        //            var service = new ServiceRepository();
        //            {
        //                using (var response = service.VerifyLogin("api/Login", login))
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    newUser = JsonConvert.DeserializeObject<LoginUser>(apiResponse);
        //                }
        //            }
        //            if (newUser != null)
        //            {
        //                ViewBag.message = "Login Success";
        //            }
        //            else
        //            {
        //                ViewBag.message = "incorrect";
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return View("HomePage");

        //}
        public ActionResult LoginUserZ()
        {
            return View();
        }

        //This Post Method will validate the userName & Password valid or not using WebAPI
        [HttpPost]
        public ActionResult LoginUserZ(UserViewmodel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Email) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44345/api/Login"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserViewmodel>("UserTable", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User Login ID & Password 

                    //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid User Id & Password";
                    }
                    return RedirectToAction("PackageDetails", "Package");
                }
            }
            return View();

        }
    }

}