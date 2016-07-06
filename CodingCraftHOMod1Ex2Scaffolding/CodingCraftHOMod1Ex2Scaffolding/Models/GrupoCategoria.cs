using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
    /*CategoriaProduto(supergrupo de grupos de produtos),*/
    // Seria camisetas, camisas, moletons
    [Table("GrupoCategoria")]
    public class GrupoCategoria
    {
        [Key]
        public long GrupoCategoriaId { get; set; }

        [Required]
        public string NomeGrupoCategoria { get; set; }

        public List<Produto> Produto { get; set; }

    }
}