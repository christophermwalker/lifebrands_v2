using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetuserlogins
    {
        [Key]
        public int LoginProvider { get; set; }
        [Required]
        public String ProviderKey { get; set; }
        [Required]
        public String UserId { get; set; }

    }

}