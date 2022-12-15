using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
   
    public class AdminImplement : IAdmin
    {
        private readonly CarWashEntities _context;
        public AdminImplement()
        {
            _context = new CarWashEntities();
        }
        public AdminImplement(CarWashEntities context)
        {
            _context = context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }
        public Admin GetById(int Id)
        {
            return _context.Admins.Find(Id);
        }
        public void InsertAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void UpdateAdmin(int Id, Admin admin)
        {
            var _admin = _context.Admins.Find(Id, admin);
            _admin.Id = admin.Id;
            _admin.Email = admin.Email;
            _admin.Password = admin.Password;
            
            _context.SaveChanges();

        }
        public void DeleteAdmin(int Id)
        {
            Admin admin = _context.Admins.Find(Id);
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        

       
    }
}