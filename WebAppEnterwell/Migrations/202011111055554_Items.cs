namespace WebAppEnterwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Items : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                        TotalItemPrice = c.Double(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            AddColumn("dbo.Invoices", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "TotalAmountIncludingTax", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "InvoiceId" });
            DropColumn("dbo.Invoices", "TotalAmountIncludingTax");
            DropColumn("dbo.Invoices", "TotalAmount");
            DropTable("dbo.Items");
        }
    }
}
