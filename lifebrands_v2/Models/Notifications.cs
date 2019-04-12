using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class Notifications
    {
        [Key]
        public int idNotifications { get; set; }
        [Required]
        public String subject { get; set; }
        [Required]
        public String comments { get; set; }

    }

}