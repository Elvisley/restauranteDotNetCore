using System.Linq;
using restaurante.Models;

namespace restaurante.Services.Contracts {
    public interface IRestauranteService{
        Restaurante Get(int id);
        IQueryable<Restaurante> GetAll();
        void Add(Restaurante entity);
        void Update(Restaurante entity);
        Restaurante Delete(int entity);
    }
}