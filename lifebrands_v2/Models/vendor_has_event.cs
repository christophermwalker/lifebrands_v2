using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lifebrands_v2.Entities
{
    public class vendor_has_event
    {
        [Key]
        public int vendor_idVendor { get; set; }
        [Required]
        public String event_idEvent { get; set; }
     
    }

}