using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ItemId { get; set; }
        public string ItenName { set; get; }
        public int Quantity { set; get; }

    }
}