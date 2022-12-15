using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class UserTableController : Controller
    {
        // GET: UserTable
        public async Task<ActionResult> Index()
        {
            List<UserTableViewModel> users = new List<UserTableViewModel>();
            var service = new ServicesRepositoryUser();
            {
                using (var response = service.GetResponse("UserTable"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject
                                  <List<UserTableViewModel>>(apiResponse);
                }
            }
            return View(users);

        }
        public async Task<ActionResult> Create(UserTableViewModel userTableViewModel)
        {
            if (ModelState.IsValid)
            {
                UserTableViewModel userTable = new UserTableViewModel();
                var service = new ServicesRepositoryUser();
                {
                    using (var response = service.PostResponse("UserTable", userTableViewModel)) ;
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        userTable = JsonConvert.DeserializeObject<UserTableViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userTableViewModel);
        }
        public async Task<ActionResult> Delete()
        {
            List<UserTableViewModel> users = new List<UserTableViewModel>();
            var service = new ServicesRepositoryUser();
            {
                using (var response = service.DeleteReponse("UserTable"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject
                                  <List<UserTableViewModel>>(apiResponse);
                }
            }
            return View(users);

}   }   }