namespace DataAnnotations.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql:"GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "DateCreated");
        }
    }
}
