using CarWashMVC.Models;
using CarWashApi.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace CarWashMVC.Controllers
{
    public class UserTableController : Controller
    {
        // GET: UserTable
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("User"))
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
                    using (var response = service.PostResponse("users", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser
                            = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



               return RedirectToAction("Index");
            }
            return View(user);
        }
    }   }
       
