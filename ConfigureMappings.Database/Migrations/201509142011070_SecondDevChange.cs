namespace ConfigureMappings.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondDevChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "SecondDevChange", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "SecondDevChange");
        }
    }
}
