using System;
using System.Linq;
using restaurante.Configuration;
using restaurante.Models;
using restaurante.Repositories.Contracts;

namespace restaurante.Repositories {
    public class PratoRepository : IPratoRepository
    {

        protected DataBaseContext Context = new DataBaseContext();

         public void Add(Prato entity)
        {
            Context.Pratos.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Prato entity)
        {
            Context.Pratos.Remove(entity);
            Context.SaveChanges();
        }

        public Prato Get<TKey>(TKey id)
        {
            return Context.Pratos.Find(id);
        }

        public IQueryable<Prato> GetAll()
        {
            return Context.Pratos;
        }

        public void Update(Prato entity)
        {
            Context.Pratos.Update(entity);
            Context.SaveChanges();
        }
    }
}