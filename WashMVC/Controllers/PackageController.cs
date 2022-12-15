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
    }
}