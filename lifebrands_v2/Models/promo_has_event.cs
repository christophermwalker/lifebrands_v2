using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class promo_has_event
    {
        [Key]
        public int promo_idPromo { get; set; }
        [Required]
        public String event_idEvent { get; set; }

    }

}