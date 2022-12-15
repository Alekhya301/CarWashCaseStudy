using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IPackage<TEntity>
    {
        IEnumerable<TEntity> Get();

        Package GetById(int id);

        void Add(TEntity user);

        void Delete(int Id);

        void Update(int Id, Package package);
        void SaveChanges();
    }
}