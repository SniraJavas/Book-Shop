using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Carts
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ItemId { get; set; }

        public int Quantity { set;  get; }


    }
}