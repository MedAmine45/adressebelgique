namespace AdresseBelgique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localite1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.street", "Localite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.street", "Localite");
        }
    }
}
