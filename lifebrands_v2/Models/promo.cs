using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class promo
    {
        [Key]
        public int idPromo { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String description { get; set; }

    }

}