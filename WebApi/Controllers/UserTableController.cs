using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;


namespace WebApi.Controllers
{

    [RoutePrefix("api/UserTable")]
    public class UserTableController : ApiController
    {
        IUserTable<UserTable> _usertable;
        public UserTableController()
        {
            this._usertable = new UserTableImplement(new CarWashEntities());
        }

        //ActionMethod to Create user
        #region
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(UserTable user)
        {
            UserTable userObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _usertable.Add(user);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Saved Successfully");


        }
        #endregion
        //ActionMethod To Get all users
        #region

        [HttpGet]
        [Route("")]
        public IEnumerable<UserTable> Get()
        {
            var users = _usertable.Get();
            return users;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _usertable.Delete(Id);
            if (Id <= 0)
                return BadRequest("Not a valid id");

            return Ok("Deleted successfully");


        }
        #endregion
        //ActionMethod to Update User
        #region
        [HttpPut]
        public IHttpActionResult Update( int Id, UserTable user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                _usertable.Update(Id, user);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");




        }
        #endregion
        //ActionMethod to get User by Id
        #region
        [HttpGet]
        public UserTable GetById(int Id)
        {
            var user = _usertable.GetById(Id);
            return user;
        }
        #endregion

    }
}

