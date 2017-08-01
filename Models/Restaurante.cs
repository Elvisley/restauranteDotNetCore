
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurante.Models{
    
    public class Restaurante{

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Logo { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public virtual ICollection<Prato> Pratos { get; set; }
    }

}