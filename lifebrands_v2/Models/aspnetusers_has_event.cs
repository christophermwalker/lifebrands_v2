using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class aspnetusers_has_events
    {
        [Key]
        public int aspnetusers_Id { get; set; }
        [Required]
        public String event_idEvent { get; set; }

    }

}