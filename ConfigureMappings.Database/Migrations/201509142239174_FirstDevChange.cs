namespace ConfigureMappings.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDevChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "FirstDevChange", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leagues", "FirstDevChange");
        }
    }
}
