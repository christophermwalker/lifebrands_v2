using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class event_has_promo
    {
        [Key]
        public int Event_idEvent { get; set; }
        [Required]
        public String Promo_idPromo { get; set; }

    }

}