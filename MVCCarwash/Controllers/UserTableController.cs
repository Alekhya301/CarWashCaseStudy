using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCCarwash.Models;
using MVCCarwash.Repositories;
using Newtonsoft.Json;

namespace MVCCarwash.Controllers
{
    public class UserTableController : Controller
    {
        // GET: UserTable
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
                    using (var response = service.PostResponse("api/UserTable", user))
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
        public async Task<ActionResult> Delete(int Id)
        {
            var services = new ServiceRepository();
            {
                using (var response = services.DleteResponse("users/",Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}