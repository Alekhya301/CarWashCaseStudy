using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICar<TEntity>
    {
        IEnumerable<TEntity> Get();

        Car GetById(int id);

        void Add(TEntity car);

        void Delete(int Id);

        void Update(int Id, Car car);
        void SaveChanges();
    }
}