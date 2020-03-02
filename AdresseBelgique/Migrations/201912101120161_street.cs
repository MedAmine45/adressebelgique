namespace AdresseBelgique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class street : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.street",
                c => new
                    {
                        RueId = c.Int(nullable: false, identity: true),
                        Cps = c.Int(nullable: false),
                        NomRue = c.String(),
                        Commune = c.String(),
                        xMin = c.Double(nullable: false),
                        xMax = c.Double(nullable: false),
                        yMin = c.Double(nullable: false),
                        yMax = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.street");
        }
    }
}
