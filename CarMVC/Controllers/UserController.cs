using CarMVC.Models;
using CarMVC.Repository;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("UserTable"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("UserTable", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction("Index");
            }
            return View(user);
        }
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using(var response = service.DeleteResponse("UserTable/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditUser(int Id)
        {
            UserViewModel user = new UserViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.UpdateResponse("UserTable/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return View(user);
        }
        

    }
}