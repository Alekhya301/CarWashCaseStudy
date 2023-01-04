using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WashMVC.Models;
using WashMVC.Repositories;

namespace WashMVC.Controllers
{
    public class PackageController : Controller
    {
        //To display all packages
        #region
        public async Task<ActionResult> PacakgeDetails()
        {
            List<PackageViewModel> packages = new List<PackageViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Package"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    packages = JsonConvert.DeserializeObject<List<PackageViewModel>>(apiResponse);
                }
            }
            return View(packages);
        }
        #endregion
        //ActionMethod to delete Package
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("Package/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("PacakgeDetails");
        }
        #endregion

        //Action method to create Package
        #region
        public async Task<ActionResult> Create(PackageViewModel user)
        {
            if (ModelState.IsValid)
            {
                PackageViewModel newUser = new PackageViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Package", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewmodel>(apiResponse);
                    }
                }



                return RedirectToAction("PacakgeDetails", "Package");
            }
            return View(user);
        }
        #endregion


        //Actionmethod to update user
        //public ActionResult EditUser()
        //{
        //    return View();
        //}
        //#region
        //[HttpPut]
        //public async Task<ActionResult> EditUser(int Id)
        //{
        //    PackageViewModel user = new PackageViewModel();
        //    var service = new ServiceRepository();
        //    {
        //        using (var response = service.UpdateResponse("Package/", Id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            user = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
        //        }
        //    }
        //    return View(user);
        //}
        //#endregion

        // GET: users/Edit/5
       
        public async Task<ActionResult> Edit(int id)
        {
            PackageViewModel package = new PackageViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Package" + "/" + id))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    package
                        = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
                }
            }
            return View(package);
        }



        [HttpPost]

        public async Task<ActionResult> Edit(PackageViewModel package)
        {
            PackageViewModel updatepackage = new PackageViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("Package"
                + "/" + package.Id, package))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //updatepackage = JsonConvert
                       // .DeserializeObject<PackageViewModel>(apiResponse);
                }
            }
            return RedirectToAction("PacakgeDetails");
        }



    }
}