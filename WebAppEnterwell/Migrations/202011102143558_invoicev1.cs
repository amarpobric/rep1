namespace WebAppEnterwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoicev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        PaymentDueDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        InvoiceFor = c.String(),
                        PDVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.PDVs", t => t.PDVId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.PDVId);
            
            CreateTable(
                "dbo.PDVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "PDVId", "dbo.PDVs");
            DropForeignKey("dbo.Invoices", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Invoices", new[] { "PDVId" });
            DropIndex("dbo.Invoices", new[] { "ApplicationUserId" });
            DropTable("dbo.PDVs");
            DropTable("dbo.Invoices");
        }
    }
}
