using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetusers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String PasswordHash { get; set; }
        [Required]
        public String SecurityStamp { get; set; }
        [Required]
        public String PhoneNumber{ get; set; }
        [Required]
        public String UserName { get; set; }
    }

}