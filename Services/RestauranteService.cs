using System;
using System.Linq;
using restaurante.Models;
using restaurante.Repositories.Contracts;
using restaurante.Services.Contracts;

namespace restaurante.Services{
    public class RestauranteService : IRestauranteService
    {

        protected IRestauranteRepository iRestRepository;    

        public RestauranteService(IRestauranteRepository i){
            iRestRepository = i;
        }

        public void Add(Restaurante entity)
        {
            iRestRepository.Add(entity);
        }

        public Restaurante Delete(int id)
        {
            Restaurante entity = iRestRepository.Get(id);
            iRestRepository.Delete(entity);
            return entity;
        }

        public Restaurante Get(int id)
        {
            return iRestRepository.Get(id);
        }

        public IQueryable<Restaurante> GetAll()
        {
            return iRestRepository.GetAll();
        }

        public void Update(Restaurante entity)
        {
            iRestRepository.Update(entity);
        }
    }
}