using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetuserroles
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public String RoleId { get; set; }

    }

}