using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
   /* A loja consistia nas entidades: Produto(com tamanho, cor, estilo da gola, preço e estoque),*/ 
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public long ProdutoId { get; set; }

        public long GrupoCategoriaId { get; set; }

        public long GrupoProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string EstiloGola { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public int Estoque { get; set; }

        /// <summary>
        /// FKs
        /// </summary>
         [ForeignKey("GrupoCategoriaId")]
        public virtual GrupoCategoria GrupoCategoria { get; set; }

        [ForeignKey("GrupoProdutoId")]
        public virtual GrupoProduto GrupoProduto { get; set; }

        public ICollection<Tag> Tag { get; set; }


        // Produto poderá ter várias vendas
        public ICollection<Venda> Venda { get; set; }




    }
}