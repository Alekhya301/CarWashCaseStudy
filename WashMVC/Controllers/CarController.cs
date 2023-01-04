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
    public class CarController : Controller
    {
        //To display all car details
        #region
        public async Task<ActionResult> CarDetails()
        {
            List<CarViewModel> cars = new List<CarViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Car"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<CarViewModel>>(apiResponse);
                }
            }
            return View(cars);
        }
        #endregion
        //ActionMethod to delete car details
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("Car/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CarDetails");
        }
        #endregion

        //Action method to add car details
        #region
        public async Task<ActionResult> Create(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                    CarViewModel newcar = new CarViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Car" , car))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewmodel>(apiResponse);
                    }
                }



                return RedirectToAction("CarDetails", "Car");
            }
            return View(car);
        }
        #endregion
        //Actionmethod to update car details
        #region
        // GET: users/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            CarViewModel car = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Car" + "/" + id))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    car
                        = JsonConvert.DeserializeObject<CarViewModel>(apiResponse);
                }
            }
            return View(car);
        }



        [HttpPost]

        public async Task<ActionResult> Edit(CarViewModel car)
        {
            CarViewModel cars = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("Car"
                + "/" + cars.Id, cars))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //updatepackage = JsonConvert
                    // .DeserializeObject<PackageViewModel>(apiResponse);
                }
            }
            return RedirectToAction("CarDetails");
        }
        #endregion
    }
}