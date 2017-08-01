using System.Collections.Generic;
using System.Linq;
using restaurante.Models;

namespace restaurante.Services.Contracts {
    public interface IPratoService{
        Prato Get(int id);
        IQueryable<Prato> GetAll();
        void Add(Prato entity);
        void Update(Prato entity);
        Prato Delete(int entity);
        IEnumerable<Prato> GetPratosRestaurante(int id);
    }
}