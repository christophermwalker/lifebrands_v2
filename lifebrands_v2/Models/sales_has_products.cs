using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class sales_has_products
    {
        [Key]
        public int sales_idSale { get; set; }
        [Required]
        public String products_idProduct { get; set; }

    }

}