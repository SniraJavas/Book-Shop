namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //public partial class Fill_Db : DbMigration
    //{
    //    public override void Up()
    //    {
    //        RenameTable(name: "dbo.Users", newName: "Logins");
    //        DropPrimaryKey("dbo.Logins");
    //        CreateTable(
    //            "dbo.Carts",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    UserName = c.String(),
    //                    ItemId = c.Int(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        CreateTable(
    //            "dbo.Items",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Name = c.String(),
    //                    Price = c.Int(nullable: false),
    //                    Description = c.String(),
    //                    Category = c.String(),
    //                    Offer = c.Int(nullable: false),
    //                    ImagePath = c.String(),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        AddColumn("dbo.Logins", "Login_Id", c => c.Int(nullable: false, identity: true));
    //        AddColumn("dbo.Logins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
    //        AlterColumn("dbo.Logins", "Id", c => c.Int());
    //        AlterColumn("dbo.Logins", "FirstName", c => c.String());
    //        AlterColumn("dbo.Logins", "LastName", c => c.String());
    //        AlterColumn("dbo.Logins", "Email", c => c.String());
    //        AddPrimaryKey("dbo.Logins", "Login_Id");
    //    }
        
    //    public override void Down()
    //    {
    //        DropPrimaryKey("dbo.Logins");
    //        AlterColumn("dbo.Logins", "Email", c => c.String(nullable: false));
    //        AlterColumn("dbo.Logins", "LastName", c => c.String(nullable: false));
    //        AlterColumn("dbo.Logins", "FirstName", c => c.String(nullable: false));
    //        AlterColumn("dbo.Logins", "Id", c => c.Int(nullable: false, identity: true));
    //        DropColumn("dbo.Logins", "Discriminator");
    //        DropColumn("dbo.Logins", "Login_Id");
    //        DropTable("dbo.Items");
    //        DropTable("dbo.Carts");
    //        AddPrimaryKey("dbo.Logins", "Id");
    //        RenameTable(name: "dbo.Logins", newName: "Users");
    //    }
    //}
}
