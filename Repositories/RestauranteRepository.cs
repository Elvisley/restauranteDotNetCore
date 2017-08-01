using System;
using System.Linq;
using restaurante.Configuration;
using restaurante.Models;
using restaurante.Repositories.Contracts;

namespace restaurante.Repositories{

    public class RestauranteRepository : IRestauranteRepository
    {

        protected DataBaseContext Context = new DataBaseContext();

        public void Add(Restaurante entity)
        {
            Context.Restaurantes.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(Restaurante entity)
        {
            Context.Restaurantes.Remove(entity);
            Context.SaveChanges();
        }

        public Restaurante Get<TKey>(TKey id)
        {
            return Context.Restaurantes.Find(id);
        }

        public IQueryable<Restaurante> GetAll()
        {
            return Context.Restaurantes;
        }

        public void Update(Restaurante entity)
        {
            Context.Restaurantes.Update(entity);
            Context.SaveChanges();
        }
    }

}