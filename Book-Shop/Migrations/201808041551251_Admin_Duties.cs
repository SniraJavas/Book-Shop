namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_Duties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ItemId = c.Int(nullable: false),
                        ItenName = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        Category = c.String(),
                        Offer = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemModels");
            DropTable("dbo.CartModels");
        }
    }
}
