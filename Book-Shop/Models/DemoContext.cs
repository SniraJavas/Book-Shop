using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Data.Entity;
namespace BookShop.Models
{
    public class DemoContext : DbContext
    {

        public DbSet<Item> Item { get; set; }
        public DbSet<Carts> Cart { get; set; }
        public DbSet<Login1> Login { get; set; }
        public DbSet<Users> Users { get; set; }

        public System.Data.Entity.DbSet<BookShop.ViewModels.CartModel> CartModels { get; set; }

        public System.Data.Entity.DbSet<BookShop.ViewModels.ItemModel> ItemModels { get; set; }
    }
}