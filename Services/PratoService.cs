using System;
using System.Collections.Generic;
using System.Linq;
using restaurante.Models;
using restaurante.Repositories.Contracts;
using restaurante.Services.Contracts;

namespace restaurante.Services{

    public class PratoService : IPratoService
    {

        protected IPratoRepository iPraRepository;

        public PratoService(IPratoRepository iprato){
            iPraRepository = iprato;
        }

        public void Add(Prato entity)
        {
            iPraRepository.Add(entity);
        }

        public Prato Delete(int id)
        {
            Prato entity = iPraRepository.Get(id);
            iPraRepository.Delete(entity);
            return entity;
        }

        public Prato Get(int id)
        {
            return iPraRepository.Get(id);
        }

        public IQueryable<Prato> GetAll()
        {
            return iPraRepository.GetAll();
        }

        public IEnumerable<Prato> GetPratosRestaurante(int id)
        {
            return iPraRepository.GetAll().Where(p => p.RestauranteId == id);
        }

        public void Update(Prato entity)
        {
            iPraRepository.Update(entity);
        }
    }
}