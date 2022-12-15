using CarMVC.Models;
using CarMVC.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //This Action method is used to display Login View
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(UserLoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return View("HomePage");

        }

        //This Post Method will validate the userName & Password valid or not using WebAPI
        [HttpPost]
        public ActionResult LoginUserZ(UserViewModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Email) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44345/api/Login"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserViewModel>("custLogin", Ur);//Asynchronosly passing the values in Json Format to API
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
                }
            }
            return View();

        }
    }

}
