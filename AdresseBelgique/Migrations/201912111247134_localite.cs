namespace AdresseBelgique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localite",
                c => new
                    {
                        LocaliteID = c.Int(nullable: false, identity: true),
                        Localitenom = c.String(),
                        Commune = c.String(),
                        Cps = c.Int(nullable: false),
                        xMin = c.Double(nullable: false),
                        xMax = c.Double(nullable: false),
                        yMin = c.Double(nullable: false),
                        yMax = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocaliteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Localite");
        }
    }
}
