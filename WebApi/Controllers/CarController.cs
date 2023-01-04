using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {
       
        ICar<Car> _car;
        public CarController()
        {
            this._car = new ICarImplement(new CarWashEntities());
        }

        //ActionMethod to give car details
        #region
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Car car)
        {
            UserTable carObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _car.Add(car);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Saved Successfully");


        }
        #endregion
        //ActionMethod To Get all cars details
        #region

        [HttpGet]
        [Route("")]
        public IEnumerable<Car> Get()
        {
            var cars = _car.Get();
            return cars;
        }
        #endregion
        //Actionmethod to delete car details
        #region
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _car.Delete(Id);
            if (Id <= 0)
                return BadRequest("Not a valid id");

            return Ok("Deleted successfully");


        }
        #endregion
        //ActionMethod to Update car details
        #region
        [HttpPut]
        public IHttpActionResult Update(int Id, Car car)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                _car.Update(Id, car);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");




        }
        #endregion
        //ActionMethod to get car details  by Id
        #region
        [HttpGet]
        public Car GetById(int Id)
        {
            var car = _car.GetById(Id);
            return car;
        }
        #endregion

    }
}
