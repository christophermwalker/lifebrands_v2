﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lifebrands_v2.Entities
{
    public class ProductsMaster
    {
        [Key]
        public String idProduct { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String cost { get; set; }
        [Required]
        public String wholesale_cost { get; set; }
        [Required]
        public String retail_price { get; set; }
    }

}