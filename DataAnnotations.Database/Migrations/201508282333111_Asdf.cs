namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asdf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
