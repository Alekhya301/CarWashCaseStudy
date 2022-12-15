using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApi.Models;


namespace WebApi.Repositories
{
    public interface IUserTable<TEntity>
    {
      IEnumerable<TEntity> Get();

        UserTable GetById(int id);

        void Add(TEntity user);

        void Delete(int Id);

        void Update(int Id,UserTable user);
        void SaveChanges();
    }
}