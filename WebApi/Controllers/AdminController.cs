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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
       
       
            private IAdmin _admin;
            public AdminController()
            {
                this._admin = new AdminImplement(new CarWashEntities());
            }


            [System.Web.Http.HttpPostAttribute]
            public HttpResponseMessage InsertAdmin(Admin admin)
            {
                _admin.InsertAdmin(admin);
                return Request.CreateResponse(HttpStatusCode.OK, InsertAdmin(admin));
            }
            [HttpGet]
            public HttpResponseMessage GetAll()
            {
                return Request.CreateResponse(HttpStatusCode.OK, _admin.GetAll());
            }

            [System.Web.Http.HttpPutAttribute]
            public HttpResponseMessage UpdateAdmin(int Id, Admin admin)
            {
                _admin.UpdateAdmin(Id, admin);
                return Request.CreateResponse(HttpStatusCode.OK, UpdateAdmin(Id, admin));
            }

            [System.Web.Http.HttpDeleteAttribute]
            public HttpResponseMessage DeleteAdmin(int Id)
            {
                _admin.DeleteAdmin(Id);
                return Request.CreateResponse(HttpStatusCode.OK, DeleteAdmin(Id));

            }
            public HttpResponseMessage GetbyId(int Id)
            {
                _admin.GetById(Id);
                return Request.CreateResponse(HttpStatusCode.OK, _admin.GetById(Id));
            }

        }
    }
