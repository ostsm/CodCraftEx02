using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
   /* GrupoProduto(nome do produto com a especificação da estampa, qual categoria pertence),*/ 
   // seria manga longa, estampa frente / costas, 
   [Table("GrupoProduto")]
    public class GrupoProduto
    {
        [Key]
        public long GrupoProdutoId { get; set; }

        [Required]
        public string NomeGrupoProduto { get; set; }

        public ICollection<Produto> Produto { get; set; }

    }
}