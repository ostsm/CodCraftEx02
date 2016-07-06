using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
    /* Tag(um grupo de produto pode ter várias tags, que facilitam a pesquisa por produtos similares) */
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public long TagId { get; set; }

        [Required]
        public string TagNome { get; set; }


        // FK relacionar produto com TAG
        public List<Produto> Produto { get; set; }
    }
}