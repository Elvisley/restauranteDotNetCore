
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurante.Models{
    
    public class Prato{

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public decimal Preco { get; set; }

        public int RestauranteId { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}