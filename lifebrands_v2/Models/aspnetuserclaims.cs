using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetuserclaims
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String UserID { get; set; }
        [Required]
        public String ClaimType { get; set; }
        [Required]
        public String ClaimValue { get; set; }
        
    }

}