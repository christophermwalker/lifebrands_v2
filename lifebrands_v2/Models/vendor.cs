using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class vendor
    {
        [Key]
        public int idVendor { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String address { get; set; }
        [Required]
        public String city { get; set; }
        [Required]
        public String state { get; set; }
        [Required]
        public String zip { get; set; }

    }

}