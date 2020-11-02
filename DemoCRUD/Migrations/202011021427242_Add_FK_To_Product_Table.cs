namespace DemoCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FK_To_Product_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropColumn("dbo.Product", "CategoryId");
        }
    }
}
