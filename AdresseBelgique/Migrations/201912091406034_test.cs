namespace AdresseBelgique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Commune",
                c => new
                    {
                        CommuneID = c.Int(nullable: false, identity: true),
                        cps = c.Int(nullable: false),
                        nom = c.String(),
                        xMin = c.Double(nullable: false),
                        xMax = c.Double(nullable: false),
                        yMin = c.Double(nullable: false),
                        yMax = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CommuneID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Commune");
            DropTable("dbo.Address");
        }
    }
}
