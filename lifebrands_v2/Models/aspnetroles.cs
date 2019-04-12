using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetroles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
      
    }

}