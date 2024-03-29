﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Offer { get; set; }
        public string ImagePath { get; set; }
    }
}