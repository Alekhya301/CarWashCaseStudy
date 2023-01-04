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
    public class UserController : Controller
    {
        // GET: User
        // GET: User
        //ActionMethod to Get Users
        #region
        public async Task<ActionResult> Index()
        {
            List<UserViewmodel> users = new List<UserViewmodel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("UserTable"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewmodel>>(apiResponse);
                }
            }
            return View(users);
        }
        #endregion
     
        
        //ActionMethod to delete user
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("UserTable/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
        //Actionmethod to update user
        #region
        // GET: users/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            UserViewmodel user = new UserViewmodel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("UserTable" + "/" + id))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    user
                        = JsonConvert.DeserializeObject<UserViewmodel>(apiResponse);
                }
            }
            return View(user);
        }



        [HttpPost]

        public async Task<ActionResult> Edit(UserViewmodel user)
        {
            UserViewmodel users = new UserViewmodel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("UserTable"
                + "/" + user.Id, user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //updatepackage = JsonConvert
                    // .DeserializeObject<PackageViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index","User");
        }
        #endregion




    }
}