using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IAdmin
    {
        IEnumerable<Admin> GetAll();
        Admin GetById(int Id);
        void InsertAdmin(Admin admin);
        void UpdateAdmin(int Id, Admin admin);
        void DeleteAdmin(int Id);
        void Save();
    }
}