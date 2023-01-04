using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ICarImplement : ICar<Car>
    {
        CarWashEntities _context;

        public ICarImplement(CarWashEntities context)
        {
            _context = context;
        }
        //To Get all Users Method
        #region
        public IEnumerable<Car> Get()
        {
            return _context.Cars.ToList();
        }
        #endregion
        //To add user method
        #region
        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();


        }
        #endregion
        //method to delete user
        #region
        public void Delete(int Id)
        {
            Car car = _context.Cars.Find(Id);
            _context.Cars.Remove(car);
            _context.SaveChanges();

        }
        #endregion
        //method to update user
        #region
        public void Update(int Id, Car car)
        {

            var _car = _context.Cars.Find(Id);
            _car.Id = car.Id;
            _car.CarModel = car.CarModel;
            _car.Status = car.Status;
            _context.Entry(_car).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();


        }
        #endregion

        //method to get user by Id
        #region

        public Car GetById(int Id)
        {
            return _context.Cars.Find(Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}