namespace ConsoleApp17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        login = c.String(),
                        Password = c.String(),
                        Cart_id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_id)
                .Index(t => t.Cart_id);
            
            CreateTable(
                "dbo.ItemCarts",
                c => new
                    {
                        Item_id = c.Guid(nullable: false),
                        Cart_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_id, t.Cart_id })
                .ForeignKey("dbo.Items", t => t.Item_id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_id, cascadeDelete: true)
                .Index(t => t.Item_id)
                .Index(t => t.Cart_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Cart_id", "dbo.Carts");
            DropForeignKey("dbo.ItemCarts", "Cart_id", "dbo.Carts");
            DropForeignKey("dbo.ItemCarts", "Item_id", "dbo.Items");
            DropIndex("dbo.ItemCarts", new[] { "Cart_id" });
            DropIndex("dbo.ItemCarts", new[] { "Item_id" });
            DropIndex("dbo.Users", new[] { "Cart_id" });
            DropTable("dbo.ItemCarts");
            DropTable("dbo.Users");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
