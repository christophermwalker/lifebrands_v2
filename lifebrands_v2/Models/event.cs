using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class event
    {
        [Key]
        public int idEvent { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String description { get; set; }
    }
}