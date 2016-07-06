using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
    /* Venda(detalhando grupos de produtos, quantidades, data da compra e usuário, que vem do ASP.NET Identity).*/
    [Table("Venda")]
    public class Venda
    {
        [Key]
        public long VendaId { get; set; }

        
        [Required]
        public long UsuarioId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime DtCompra { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        

    }
}