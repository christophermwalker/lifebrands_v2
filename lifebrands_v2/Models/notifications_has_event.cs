using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class notifications_has_event
    {
        [Key]
        public int notifications_idNotifications { get; set; }
        [Required]
        public String event_idEvent { get; set; }
    }

}